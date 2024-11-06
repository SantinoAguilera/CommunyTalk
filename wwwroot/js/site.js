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