import * as THREE from "three";
import { TextGeometry } from "three/addons/geometries/TextGeometry.js";
import WebGL from "three/addons/capabilities/WebGL.js";

/**
 * ? CREATE TEXTS
 */

const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(
  45,
  window.innerWidth / window.innerHeight,
  1,
  500
);

const renderer = new THREE.WebGLRenderer();
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

const geometry = new TextGeometry("Hello three.js!", {
  font: font,
  size: 80,
  height: 5,
  curveSegments: 12,
  bevelEnabled: true,
  bevelThickness: 10,
  bevelSize: 8,
  bevelOffset: 0,
  bevelSegments: 5,
});

const material = new THREE.CSS2Renderer();
const text = new THREE.Text(geometry, material);
scene.add(text);

function animate() {
  requestAnimationFrame(animate);

  renderer.render(scene, camera);
}

// const texture = new THREE.TextureLoader().load("img/devil.png");

// texture.wrapS = THREE.RepeatWrapping;
// texture.wrapT = THREE.RepeatWrapping;
// texture.repeat.set(4,4);

// Initiate function or other initializations here animate();
if (WebGL.isWebGLAvailable()) {
  animate();
} else {
  const warning = WebGL.getWebGLErrorMessage();
  document.getElementById("container").appendChild(warning);
}
