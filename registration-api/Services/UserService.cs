using System;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        User Create(User user);
    }

    public class UserService : IUserService
    {
        private DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            // validation
            if (user != null)
            {
                Guid guid = Guid.NewGuid();
                Random random = new Random();
                int i = random.Next();
                user.CustomerID = i;
            }

            string emailOrDob = (!string.IsNullOrWhiteSpace(user.EmailId) ? user.EmailId : (!string.IsNullOrWhiteSpace(user.DOB)) ? user.DOB : "");
            if (string.IsNullOrWhiteSpace(emailOrDob))
            {
                throw new AppException("Email or Dob is required");
            }
            if (!string.IsNullOrWhiteSpace(user.DOB))
            {
                IsLegalAge(user.DOB);
            }
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public bool IsLegalAge(string inputDate)
        {
            try
            {
                var bday = Convert.ToDateTime(inputDate);
                var ts = DateTime.Today - bday;
                var year = DateTime.MinValue.Add(ts).Year - 1;
                if (year >= 18)
                {
                    return true;
                }
                else
                {
                    throw new AppException("DOB should be 18 years old");
                }
            }
            catch (AppException ex)
            {
                throw new AppException("Input date is not valid");
            }
            
        }
    }
}