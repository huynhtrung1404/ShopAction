import  PasswordCheck  from "./passwordExtention.js";

$(document).ready(() => {
  $('.password-rule').keyup(() => {
      $('.show-error').text(PasswordCheck.passwordStrength($('.password-rule').val()))
  })
})
