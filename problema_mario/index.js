function init() {
  let chover = false;
  let correr = true;
  let surfar = false;

  if (correr) {
    chover = true;
  }

  if (!chover) {
    surfar = true;
    correr = false;
    document.getElementById("result4").innerHTML = "Mario surfou";
    document.getElementById("result5").innerHTML = "";
  }

  if (correr && surfar !== correr) {
    document.getElementById("result4").innerHTML = "Mario não surfou";
    document.getElementById("result5").innerHTML = "Choveu";
  }
}

init();
