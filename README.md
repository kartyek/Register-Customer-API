# Register-Customer-API
Customer Registration API

const consentDefaultValue = require('./consentDefaultValue'); // import the code to be tested

describe('consentDefaultValue', () => {
  test('should return 1 for characterCode = NIL*', () => {
    const result = consentDefaultValue('accid1', 'NIL*', true);
    expect(result).toBe(1);
  });

  test('should return 7 for characterCode = ILC*', () => {
    const result = consentDefaultValue('accid2', 'ILC*', true);
    expect(result).toBe(7);
  });

  test('should return "checked" for characterCode = TSC* and status = true', () => {
    const result = consentDefaultValue('accid3', 'TSC*', true);
    expect(result).toBe('checked');
  });

  test('should return "unchecked" for characterCode = TSC* and status = false', () => {
    const result = consentDefaultValue('accid4', 'TSC*', false);
    expect(result).toBe('unchecked');
  });

  test('should return "checked" for characterCode = *TSS', () => {
    const result = consentDefaultValue('accid5', '*TSS', true);
    expect(result).toBe('checked');
  });
});
