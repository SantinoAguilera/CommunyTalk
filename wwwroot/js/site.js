gsap.fromTo(
    ".Boton1",
    {  x: -200 },
    {  x: 20, duration: 1 }
  );
  gsap.fromTo(
    ".Boton2",
    {  x: -200 },
    {  x: 20, duration: 1 }
  );
  gsap.timeline({
    scrollTrigger: {
      scrub: 1,
      trigger: ".scroll-trigger-ready__worm-wrap",
      start: "top 90%",
      end: "bottom 30%",
    },
  });

function guardarEnStorage() {
  var nombre = document.getElementById("nombre").value;
  localStorage.setItem("nombre", nombre);
}

const interesesSeleccionados = new Set();

document.getElementById('interesesExistentes').addEventListener('change', function(){
  const opciones = Array.from(this.selectedOptions);
  opciones.forEach(opcion => interesesSeleccionados.add(opcion.value));
  actualizarHidden();
})

const agregarNuevaTag = () =>{
  const nuevaTagInput = document.getElementById('nuevaTag');
  const nuevaTag = nuevaTagInput.value.trim();
  if(nuevaTag !== ''){
    interesesSeleccionados.add(nuevaTag);
    nuevaTagInput.value = '';
    actualizarHidden();
  }  
} 

const actualizarHidden = () => {
  document.getElementById('interesesFinales').value = Array.from(interesesSeleccionados).join(',');
}