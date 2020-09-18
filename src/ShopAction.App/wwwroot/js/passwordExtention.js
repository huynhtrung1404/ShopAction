export default class PasswordCheck {

  

  static passwordStrength(password) {
    let strength = {
      "Blank": 0,
      "VeryWeak": 1,
      "Weak": 2,
      "Medium": 3,
      "Strong": 4,
      "VeryStrong": 5
    };
    var score = 0;
    if (!password || password == '') return strength.Blank;
    if (this.hasMiniumLength(password, 5)) score++;
    if (this.hasMiniumLength(password, 8)) score++;
    if (this.hasAnyLowelCase(password) && this.hasAnyUpperCase(password)) score++;
    if (this.hasDigit(password)) score++;
    if (this.hasSpecialChar(password)) score++
    return Object.keys(strength).find(key => strength[key] === score);
  }

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