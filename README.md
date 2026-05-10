# 🤖 Unity AI: Cosplay Bot (Hierarchical FSM)

<div align="left">
  <img src="https://img.shields.io/badge/Unity-FFFFFF.svg?style=flat&logo=Unity&logoColor=black" alt="Unity">
  <img src="https://img.shields.io/badge/C%23-%23239120.svg?style=flat&logo=c-sharp&logoColor=white" alt="C#">
</div>

## 📌 Overview
This project is a text-based AI simulation built in Unity, demonstrating advanced character behavior programming. The core of the project is a custom **Hierarchical Finite State Machine (HFSM)** that drives the decision-making of a "Cosplay Bot" interacting in a dynamic social environment. 

Rather than relying on visual graphics, the focus of this project is purely on **state architecture, modular code, and AI logic**, with all behaviors and state transitions logged in real-time to the Unity console.

### 🎬 Video Demonstration
[![YouTube Video](https://img.youtube.com/vi/FzfsUcyfBoM/maxresdefault.jpg)](https://youtu.be/FzfsUcyfBoM)

---

## 🧠 Technical Highlights

*   **Hierarchical State Machine (HFSM):** Designed a robust HFSM allowing for nested sub-states. For example, the `PERFORM` state smoothly branches into `SINGING`, `DANCING`, and `ACTING` substates without cluttering the global transition logic[cite: 1].
*   **Modular Architecture:** State logic is decoupled into individual class files (`IDLE.cs`, `CONVERSE.cs`, `PERFORM.cs`), ensuring the system is highly scalable and easy to debug[cite: 1].
*   **Context-Aware Transitions:** The bot dynamically transitions between states like `PROTECT`, `POSE`, and `CONVERSE` based on environmental variables (e.g., camera distance, harasser proximity, and event timers)[cite: 2].

## 🏗️ State Machine Architecture
The bot's brain is divided into several high-level states, each handling specific event logic[cite: 2]:

1.  **IDLE:** The default state, searching for interactions.
2.  **CONVERSE:** Handles dialogue interactions (greeting, giving info, rating costumes).
3.  **PERFORM:** A nested state managing active tasks (acting, singing, dancing).
4.  **POSE & PROTECT:** Reactive states triggered by spatial proximity (cameras or harassers).
5.  **PREPARE, AWAIT_RESULT, CELEBRATE:** A sequential flow for the bot competing in an event.

---

## 🎮 How to Interact (Console Controls)
The simulation is controlled via keyboard inputs that manipulate the environment and trigger state changes. Watch the Unity Console for the bot's reactions.

**Core Interactions:**
*   `C` / `I`: Move a camera into/out of detection range (<10 units)[cite: 2].
*   `H` / `I`: Move a harasser into/out of detection range[cite: 2].
*   `E`: Engage the bot in conversation[cite: 2].
*   `P`: Ask the bot to perform[cite: 2].
*   `Enter`: Start the cosplay competition[cite: 2].
*   *(See the in-game console for specific sub-state controls during conversations and performances).*

## 📁 Repository Structure
*   `Assets/Scripts/Cosplay_Bot.cs`: The primary controller script managing the bot's variables and input detection[cite: 1].
*   `Assets/Scripts/FSM/`: Contains the state machine engine (`HFSM.cs`, `State.cs`) and all individual behavior scripts[cite: 1].
