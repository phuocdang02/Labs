import * as THREE from "three";
import WebGL from "three/addons/capabilities/WebGL.js";

/**
 *? CUBE example code;
 *
 */
const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(
  75,
  window.innerWidth / window.innerHeight,
  0.1,
  1000
);

const renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, innerHeight);
document.body.appendChild(renderer.domElement);

const geometry = new THREE.BoxGeometry(1, 1, 1, 2, 2, 2);
const material = new THREE.MeshBasicMaterial({
  color: 0xee7246,
  wireframe: true,
});
const cube = new THREE.Mesh(geometry, material);
scene.add(cube);

camera.position.z = 5;

function animate() {
  requestAnimationFrame(animate);

  //Rotation
  cube.rotation.x += 0.01;
  //   cube.rotation.y += 0.01;
  cube.rotation.z += 0.01;

  renderer.render(scene, camera);
}

// Initiate function or other initializations here animate();
if (WebGL.isWebGLAvailable()) {
  animate();
} else {
  const warning = WebGL.getWebGLErrorMessage();
  document.getElementById("container").appendChild(warning);
}
