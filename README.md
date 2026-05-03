<div id="top">

<!-- HEADER STYLE: CLASSIC -->
<div align="left">


# GAME-AI-ASSIGNMENT-1

<em>Empowering Dynamic AI for Next-Gen Gaming Experiences</em>

<!-- BADGES -->
<img src="https://img.shields.io/github/last-commit/7450N/Game-AI-Assignment-1?style=flat&logo=git&logoColor=white&color=0080ff" alt="last-commit">
<img src="https://img.shields.io/github/languages/top/7450N/Game-AI-Assignment-1?style=flat&color=0080ff" alt="repo-top-language">
<img src="https://img.shields.io/github/languages/count/7450N/Game-AI-Assignment-1?style=flat&color=0080ff" alt="repo-language-count">

<em>Built with the tools and technologies:</em>

<img src="https://img.shields.io/badge/Unity-FFFFFF.svg?style=flat&logo=Unity&logoColor=black" alt="Unity">

</div>
<br>

---

## 📄 Table of Contents

- [Overview](#-overview)
- [Getting Started](#-getting-started)
    - [Prerequisites](#-prerequisites)
    - [Installation](#-installation)
    - [Usage](#-usage)
    - [Testing](#-testing)
- [Features](#-features)
- [Project Structure](#-project-structure)
    - [Project Index](#-project-index)

---

## ✨ Overview

This repository contains a text-based Unity project developed for Game AI Assignment 1[cite: 1]. It implements the behavior of a cosplay bot using a Finite State Machine (FSM)[cite: 1]. Because this is a text-based simulation, the bot's behavior, decision-making, and current state transitions are printed directly to the Unity console[cite: 1]. 

The project utilizes a Hierarchical Finite State Machine (HFSM) architecture, featuring complex nested states such as `CONVERSE`, `IDLE`, and `PERFORM` to handle various social and environmental triggers[cite: 1].

**Why Game-AI-Assignment-1?**

This project aims to facilitate the development of dynamic, scalable AI interactions within Unity. The core features include:

- 🎮 **🚦 Hierarchical Finite State Machines:** Implements HFSMs for managing complex character behaviors, enabling smooth transitions and modular behavior design.
- 🖥️ **Behavior Scripts:** Core scripts like Cosplay_Bot.cs orchestrate responsive AI actions, making character interactions more engaging and adaptable.


---

## 📌 Features

|      | Component       | Details                                                                                     |
| :--- | :-------------- | :------------------------------------------------------------------------------------------ |
| ⚙️  | **Architecture**  | <ul><li>Unity-based project leveraging C# scripts for game logic</li><li>Component-based design pattern</li><li>Uses Unity's scene hierarchy for level management</li></ul> |
| 🔩 | **Code Quality**  | <ul><li>Consistent C# coding conventions</li><li>Modular scripts with clear separation of concerns</li><li>Uses Unity's MonoBehaviour lifecycle methods effectively</li></ul> |
| 📄 | **Documentation** | <ul><li>Basic README with project overview</li><li>Inline comments in scripts</li><li>Limited external documentation or API references</li></ul> |
| 🔌 | **Integrations**  | <ul><li>Unity engine for rendering and physics</li><li>JSON files (`json`, `packages-lock.json`, `manifest.json`) for package management and configuration</li><li>Unity package dependencies managed via `manifest.json`</li></ul> |
| 🧩 | **Modularity**    | <ul><li>Separate scripts for AI behaviors, game states, and controls</li><li>Uses Unity's prefab system for reusable components</li><li>AI logic encapsulated in dedicated classes</li></ul> |
| 🧪 | **Testing**       | <ul><li>No explicit unit tests observed</li><li>Potential manual testing via Unity Editor</li><li>Possible future integration of automated tests</li></ul> |
| ⚡️  | **Performance**   | <ul><li>Optimized update loops with early exits</li><li>Minimal per-frame computations</li><li>Uses Unity's built-in physics and rendering pipelines efficiently</li></ul> |
| 🛡️ | **Security**      | <ul><li>Not applicable; local game project</li><li>No network security concerns identified</li></ul> |
| 📦 | **Dependencies**  | <ul><li>Relies on Unity engine and C# standard libraries</li><li>Package dependencies managed via `packages-lock.json` and `manifest.json`</li><li>Includes Unity-specific packages like `cosplay_bot.unity`</li></ul> |

---

## 📁 Project Structure

```sh
└── Game-AI-Assignment-1/
    ├── Assets
    │   ├── Scenes
    │   ├── Scenes.meta
    │   ├── Scripts
    │   └── Scripts.meta
    ├── Packages
    │   ├── manifest.json
    │   └── packages-lock.json
    └── README.md
```

---

### 📑 Project Index

<details open>
	<summary><b><code>GAME-AI-ASSIGNMENT-1/</code></b></summary>
	<!-- __root__ Submodule -->
	<details>
		<summary><b>__root__</b></summary>
		<blockquote>
			<div class='directory-path' style='padding: 8px 0; color: #666;'>
				<code><b>⦿ __root__</b></code>
			<table style='width: 100%; border-collapse: collapse;'>
			<thead>
				<tr style='background-color: #f8f9fa;'>
					<th style='width: 30%; text-align: left; padding: 8px;'>File Name</th>
					<th style='text-align: left; padding: 8px;'>Summary</th>
				</tr>
			</thead>
			</table>
		</blockquote>
	</details>
	<!-- Packages Submodule -->
	<details>
		<summary><b>Packages</b></summary>
		<blockquote>
			<div class='directory-path' style='padding: 8px 0; color: #666;'>
				<code><b>⦿ Packages</b></code>
			<table style='width: 100%; border-collapse: collapse;'>
			<thead>
				<tr style='background-color: #f8f9fa;'>
					<th style='width: 30%; text-align: left; padding: 8px;'>File Name</th>
					<th style='text-align: left; padding: 8px;'>Summary</th>
				</tr>
			</thead>
				<tr style='border-bottom: 1px solid #eee;'>
					<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Packages/packages-lock.json'>packages-lock.json</a></b></td>
					<td style='padding: 8px;'>- Defines project dependencies and package versions, ensuring consistent integration of Unity modules and tools across the entire codebase<br>- Facilitates seamless collaboration, testing, and development workflows by managing external packages, which underpin core functionalities such as multiplayer, UI, animation, and performance profiling within the Unity-based architecture.</td>
				</tr>
				<tr style='border-bottom: 1px solid #eee;'>
					<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Packages/manifest.json'>manifest.json</a></b></td>
					<td style='padding: 8px;'>- Defines project dependencies and module integrations essential for building a comprehensive Unity-based application<br>- It ensures consistent inclusion of core Unity modules such as UI, physics, animation, multiplayer, and analytics, facilitating a modular and scalable architecture<br>- This setup supports the development of a feature-rich, cross-platform experience by managing the foundational components required across the entire codebase.</td>
				</tr>
			</table>
		</blockquote>
	</details>
	<!-- Assets Submodule -->
	<details>
		<summary><b>Assets</b></summary>
		<blockquote>
			<div class='directory-path' style='padding: 8px 0; color: #666;'>
				<code><b>⦿ Assets</b></code>
			<!-- Scripts Submodule -->
			<details>
				<summary><b>Scripts</b></summary>
				<blockquote>
					<div class='directory-path' style='padding: 8px 0; color: #666;'>
						<code><b>⦿ Assets.Scripts</b></code>
					<table style='width: 100%; border-collapse: collapse;'>
					<thead>
						<tr style='background-color: #f8f9fa;'>
							<th style='width: 30%; text-align: left; padding: 8px;'>File Name</th>
							<th style='text-align: left; padding: 8px;'>Summary</th>
						</tr>
					</thead>
						<tr style='border-bottom: 1px solid #eee;'>
							<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/Cosplay_Bot.cs'>Cosplay_Bot.cs</a></b></td>
							<td style='padding: 8px;'>- Implements the core behavior management for the Cosplay Bot by integrating a hierarchical finite state machine (HFSM)<br>- It orchestrates the bots actions and state transitions, enabling dynamic and responsive interactions within the game environment<br>- Serves as the central control point for the bot’s activity flow, ensuring modularity and scalability in behavior design.</td>
						</tr>
					</table>
					<!-- FSM Submodule -->
					<details>
						<summary><b>FSM</b></summary>
						<blockquote>
							<div class='directory-path' style='padding: 8px 0; color: #666;'>
								<code><b>⦿ Assets.Scripts.FSM</b></code>
							<table style='width: 100%; border-collapse: collapse;'>
							<thead>
								<tr style='background-color: #f8f9fa;'>
									<th style='width: 30%; text-align: left; padding: 8px;'>File Name</th>
									<th style='text-align: left; padding: 8px;'>Summary</th>
								</tr>
							</thead>
								<tr style='border-bottom: 1px solid #eee;'>
									<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/FSM/PERFORM.cs'>PERFORM.cs</a></b></td>
									<td style='padding: 8px;'>- Defines a hierarchical finite state machine managing a characters performance activities, including waiting for tasks, singing, dancing, and acting<br>- Coordinates user input to transition between substates, controls timing for each activity, and handles the overall performance flow within a larger game architecture<br>- Facilitates dynamic performance management during interactive scenarios or competitions.</td>
								</tr>
								<tr style='border-bottom: 1px solid #eee;'>
									<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/FSM/State.cs'>State.cs</a></b></td>
									<td style='padding: 8px;'>- Defines a hierarchical finite state machine (HFSM) for managing character behaviors in a Unity-based game<br>- It orchestrates various high-level states such as posing, protecting, preparing, awaiting results, and celebrating, enabling smooth transitions based on user input and game events<br>- This structure facilitates organized, scalable control of complex character interactions within the overall game architecture.</td>
								</tr>
								<tr style='border-bottom: 1px solid #eee;'>
									<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/FSM/IDLE.cs'>IDLE.cs</a></b></td>
									<td style='padding: 8px;'>- Defines the Idle state within a finite state machine, managing the bots behavior when inactive<br>- It orchestrates sub-behaviors like looking around and roaming, while responding to user inputs and environmental cues to transition into engagement, protection, or pose states, thereby facilitating dynamic and context-aware AI behavior within the overall game architecture.</td>
								</tr>
								<tr style='border-bottom: 1px solid #eee;'>
									<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/FSM/HFSM.cs'>HFSM.cs</a></b></td>
									<td style='padding: 8px;'>- Implements a hierarchical finite state machine (HFSM) managing high-level character behaviors within the game<br>- It orchestrates state transitions such as idle, converse, pose, protect, prepare, perform, await result, and celebrate, enabling smooth, organized control over complex character actions and ensuring responsive state changes aligned with gameplay flow.</td>
								</tr>
								<tr style='border-bottom: 1px solid #eee;'>
									<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scripts/FSM/CONVERSE.cs'>CONVERSE.cs</a></b></td>
									<td style='padding: 8px;'>- Defines a hierarchical finite state machine managing conversational interactions within a cosplay event setting<br>- It orchestrates various dialogue substates, enabling dynamic responses such as greeting, providing directions, character info, costume ratings, and anime recommendations<br>- Facilitates seamless transitions based on user input, supporting an engaging, context-aware virtual assistant experience aligned with the overall event architecture.</td>
								</tr>
							</table>
						</blockquote>
					</details>
				</blockquote>
			</details>
			<!-- Scenes Submodule -->
			<details>
				<summary><b>Scenes</b></summary>
				<blockquote>
					<div class='directory-path' style='padding: 8px 0; color: #666;'>
						<code><b>⦿ Assets.Scenes</b></code>
					<table style='width: 100%; border-collapse: collapse;'>
					<thead>
						<tr style='background-color: #f8f9fa;'>
							<th style='width: 30%; text-align: left; padding: 8px;'>File Name</th>
							<th style='text-align: left; padding: 8px;'>Summary</th>
						</tr>
					</thead>
						<tr style='border-bottom: 1px solid #eee;'>
							<td style='padding: 8px;'><b><a href='https://github.com/7450N/Game-AI-Assignment-1/blob/master/Assets/Scenes/Cosplay_Bot.unity'>Cosplay_Bot.unity</a></b></td>
							<td style='padding: 8px;'>- The <code>Assets/Scenes/Cosplay_Bot.unity</code> scene file serves as a core environment within the project, encapsulating the visual and spatial setup for the Cosplay Bot experience<br>- It defines the scenes rendering and occlusion culling configurations, ensuring optimized rendering performance and visual fidelity<br>- This scene acts as the primary context where the Cosplay Bot interacts with its environment, supporting the overall architecture by providing a structured and efficient visual framework for user interactions and animations.</td>
						</tr>
					</table>
				</blockquote>
			</details>
		</blockquote>
	</details>
</details>

---

## 🚀 Getting Started

## How to Use the Bot (Controls)
You can control the environment and trigger the bot's state transitions using specific keyboard inputs while monitoring the console output.

### During IDLE State
*   Press `Enter` to flag competitionStart = true.[cite: 2]
*   Press `H` to set the distance between the harasser and the bot to be less than 10 (which is the detection range).[cite: 2]
*   Press `C` to set the distance between the camera and the bot to be less than 10 (which is the detection range).[cite: 2]
*   Press `E` to flag isEngage = true.[cite: 2]

### During PROTECT State
*   Press `Enter` to flag competitionStart = true.[cite: 2]
*   Press `I` to set the distance between the harasser and the bot to be more than 10 (which is the detection range).[cite: 2]

### During POSE State
*   Press `Enter` to flag competitionStart = true.[cite: 2]
*   Press `I` to set the distance between the camera and the bot to be more than 10 (which is the detection range).[cite: 2]

### During CONVERSE State
*   Press `Enter` to flag competitionStart = true.[cite: 2]
*   Press `I` to flag isEngage = false.[cite: 2]
*   Press `C` to take a photo with the bot.[cite: 2]
*   Press `P` to ask the bot to perform.[cite: 2]

### During PERFORM State
*   Press `Enter` to flag competitionStart = true.[cite: 2]
*   Give no input in the ACTING, SINGING, or DANCING substates to flag taskLeft = false.[cite: 2]
*   If not competing now, it will transition back to IDLE.[cite: 2]
*   If competing now, it will transition to AWAIT_RESULT.[cite: 2]

### During PREPARE State
*   If a certain time has passed, the bot's turn will arrive, and it will transition to PERFORM.[cite: 2]

### During AWAIT_RESULT State
*   Press `W` to make the bot score more than 90 (which is the required score to gain a medal).[cite: 2]
*   Press `L` to make the bot score lower than 90 (which is the required score to gain a medal).[cite: 2]

### During CELEBRATE State
*   Press `C` to set the distance between the camera and the bot to be less than 10 (which is the detection range).[cite: 2]
*   Press `E` to flag isEngage = true.[cite: 2]

## Project Structure
*   **`Assets/Scripts/FSM/`**: Contains the core architecture for the state machine, including the base `State.cs`, the hierarchical structure in `HFSM.cs`, and specific sub-state implementations like `IDLE.cs`, `CONVERSE.cs`, and `PERFORM.cs`.[cite: 1]
*   **`Assets/Scripts/Cosplay_Bot.cs`**: The primary controller script that drives the state machine and handles input.[cite: 1]

### 🧪 Demo

[![YouTube Video](https://img.youtube.com/vi/FzfsUcyfBoM/maxresdefault.jpg)](https://youtu.be/FzfsUcyfBoM)

---

<div align="left"><a href="#top">⬆ Return</a></div>

---
