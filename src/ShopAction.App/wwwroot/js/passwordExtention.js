export default class PasswordCheck {
  static hasMiniumLength(password, minLength) {
    return password.length >= minLength;
  }
  static hasMiniumUniqueChars(password, minUniqueChar) {
    let unique = password.filter(onlyUnique);
    return unique >= minUniqueChar;
  }

  static hasDigit(password) {
    let format = /\d/;
    return format.test(password);
  }

  static hasSpecialChar(password) {
    let format = /[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/;
    return format.test(password);
  }
  static hasAnyUpperCase(password) {
    let format = /[A-Z]/;
    return format.test(password);
  }
  static hasAnyLowelCase(password) {
    let format = /[a-z]/;
    return format.test(password)
  }

  static isValidPassword(password, requireLength, requiredUniqueChars, requireNonAlphanumeric, requireLowercase, requireUppercase, requireDigit) {
    let self = this
    if (!self.hasMiniumLength(password, requireLength)) return false;
    if (!self.hasMiniumUniqueChars(password, requiredUniqueChars)) return false;
    if (!self.hasSpecialChar(password) && requireNonAlphanumeric) return false;
    if (!self.hasAnyLowelCase(password) && requireLowercase) return false;
    if (!self.hasAnyUpperCase(password) && requireUppercase) return false;
    if (!self.hasDigit(password) && requireDigit) return false;
    return true;
  }

  onlyUnique(value, index, self) {
    return self.indexOf(value) === index
  }

};