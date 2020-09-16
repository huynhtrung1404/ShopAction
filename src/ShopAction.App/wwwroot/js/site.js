import  PasswordCheck  from "./passwordExtention.js";

$(document).ready(() => {
  $('.password-rule').keyup(() => {
    if (PasswordCheck.hasDigit($('.password-rule').val())) {
      alert('Password has a digit')
    }
  })
})
