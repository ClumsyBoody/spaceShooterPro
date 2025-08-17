# 🚀 Retro Space Shooter

<div align="center">

![Unity](https://img.shields.io/badge/Unity-100000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![2D](https://img.shields.io/badge/2D%20Game-FF6B6B?style=for-the-badge&logo=gamemaker&logoColor=white)

**A nostalgic arcade-style space shooter that brings back the golden age of gaming!**

*Blast through waves of enemies, collect powerful upgrades, and fight for the ultimate high score in this retro-inspired space adventure.*

</div>

---

## 🎮 Game Overview

### 🌟 Core Features
- **🎯 Classic Arcade Action** - Fast-paced shooting mechanics with pixel-perfect controls 
- **⚡ Power-Up System** - Collect upgrades to enhance your firepower and abilities
- **🏆 High Score Challenge** - Compete for the ultimate leaderboard position
- **🎨 Authentic Retro Style** - Pixel art graphics with nostalgic sound design
- **🎵 Immersive Audio** - Retro-inspired soundtrack and satisfying sound effects

### 🎲 Gameplay Mechanics
```csharp
// Core game loop
Player.Move() → Shoot() → CollectPowerUps() → AvoidEnemies() → EarnScore()
```

---

## 🖥️ Screenshots & Media

<div align="center">

### 🎬 Gameplay Preview
*[Add gameplay GIF or video here]*

| Main Menu | In-Game Action | Power-Ups |
|-----------|----------------|-----------|
| ![Menu](screenshot1.png) | ![Gameplay](screenshot2.png) | ![PowerUps](screenshot3.png) |

</div>

---

## 🛠️ Technical Specifications

<div align="center">

### 🔧 Built With
![Unity](https://img.shields.io/badge/Unity%202022.3-000000?style=flat-square&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23%2010.0-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91?style=flat-square&logo=visual-studio&logoColor=white)

</div>

### 🏗️ Architecture & Systems

| System | Implementation | Features |
|--------|---------------|----------|
| **Player Controller** | `PlayerMovement.cs` | WASD/Arrow controls, boundary constraints |
| **Shooting System** | `WeaponController.cs` | Multiple fire rates, bullet pooling |
| **Power-Up System** | `PowerUpManager.cs` | Temporary buffs, visual feedback |
| **Score System** | `ScoreManager.cs` | Point calculation |
| **Audio Manager** | `SoundController.cs` | Music loops, SFX management |

### 📊 Performance Features
- **Object Pooling** for bullets and enemies (60+ FPS maintained)
- **Efficient Collision Detection** using Unity's optimized 2D physics
- **Memory Management** with proper cleanup and disposal

---

## 🎮 Controls & Gameplay

<div align="center">

### 🕹️ Control Scheme
| Action | Keyboard | Alternative |
|--------|----------|-------------|
| **Move** | WASD / Arrow Keys | - |
| **Shoot** | Spacebar | Left Click |
| **Restart** | R | - |

</div>

### 🎯 Game Objectives
1. **Survive** waves of increasingly difficult enemies
2. **Collect** power-ups to enhance your capabilities  
3. **Achieve** the highest score possible

### ⚡ Power-Up Types
- **🔥 Movment speed** - Increases player speed
- **💥 Multi-Shot** - Fires multiple bullets simultaneously  
- **🛡️ Shield** - Temporary invincibility

---

## 🚀 Installation & Setup

### 🔽 Quick Start
```bash
# Clone the repository
git clone https://github.com/yourusername/retro-space-shooter.git

# Open in Unity
1. Launch Unity Hub
2. Click "Open" and select the project folder
3. Wait for Unity to import assets
4. Press Play in the editor or build for your platform
```

### 🏗️ Building the Game
```bash
# For Windows
File → Build Settings → PC, Mac & Linux Standalone → Build

# For WebGL (Browser)
File → Build Settings → WebGL → Build
```

---

## 🧪 Development Features

### 📈 Code Quality
- **Clean Architecture** with separated concerns
- **Commenting** and documentation throughout
- **Error Handling** for robust gameplay
- **Configurable Parameters** via Unity Inspector
- **Modular Design** for easy feature additions



## 🎯 Future Enhancements


### 🐛 Known Issues
- Minor collision detection edge cases
- Audio may overlap during intense gameplay
- Performance optimization needed for mobile
- No current settings 
---



---

<div align="center">

### 🌟 If you enjoyed this game, please give it a star!


[![Star this repo](https://img.shields.io/github/stars/yourusername/retro-space-shooter?style=social)](https://github.com/yourusername/retro-space-shooter)
[![Follow me](https://img.shields.io/github/followers/yourusername?style=social)](https://github.com/yourusername)

</div>
