export class PasswordCheck {
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

  onlyUnique(value,index,self) {
    return self.indexOf(value) === index
  }

}