# Movimiento Parabólico en C#

Este proyecto es una simulación del **movimiento parabólico** utilizando el lenguaje de programación **C#**. El objetivo es representar gráficamente y numéricamente el comportamiento de un objeto lanzado con una velocidad inicial bajo la influencia de la gravedad.

## Características

- Simulación del lanzamiento de un proyectil en dos dimensiones.
- Cálculo de:
  - Altura máxima
  - Alcance horizontal
  - Tiempo de vuelo
- Visualización de la trayectoria 
- Interfaz de usuario simple para ingresar parámetros iniciales:
  - Velocidad inicial
  - Ángulo de lanzamiento
  - Posicion inicial X y Y
  - Gravedad

## 🛠️ Tecnologías utilizadas

- Lenguaje: **C#**
- Framework: .NET 

## 📐 Fórmulas utilizadas

- Posición horizontal: `x = v0 * cos(θ) * t`
- Posición vertical: `y = v0 * sin(θ) * t - 0.5 * g * t²`

Donde:
- `v0` es la velocidad inicial
- `θ` es el ángulo de lanzamiento en grados
- `g` es la gravedad (9.8 m/s²)
- `t` es el tiempo

## ✅ Cómo ejecutar el proyecto

1. Clona este repositorio:

   ```bash
   git clone https://github.com/DajerlyMoreno/MovimientoParabolico.git
