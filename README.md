# TechTitans
This repo contains the code for the Smart Home Simulator done for the SOEN343 course
## How to deploy the Home Simulator Application

### Clone this repo
```bash
git clone https://github.com/alexsmags/TechTitans
```
### Run the .exe
```bash
TechTitans\Home Simulator\bin\Debug\Home Simulator.exe
```

# Phase I

## Team Members and Role 
| Name                  | Role                 | ID       |
| --------------------- | -------------------- | -------- |
| Alexander Smagorinski |Making Context Diagram/Review| 40190986 |
| Cosmin Suna           | Making Domain Model/Review  | 40125921 |
| Mohamad Mounir Yassin |    Documentation/Review     | 40198854 |
| Saikou Diallo         | Making Domain Model/Review  | 40191902 |
| Patrick MacEachen     | Making Domain Model/Review  | 40209790 |


# Problem Definition
## Problem Statement
The intricacies and difficulties associated with programming smart home systems are tackled by  the Smart Home Simulator project. It seeks to offer a way to coordinate different linked gadgets in a smart home setting. The simulator concentrates on addressing problems that are common to programming tasks for smart home automation, such as feature interaction, modularity, debugging, and comprehension. The project makes it easier to experiment with and find solutions for these programming issues by providing a graphical depiction of the interactions between household gadgets and IoT systems. This increases the efficacy and efficiency of developing and deploying smart home systems.

| 1                             | 2                                                                                                              |
|-------------------------------|------------------------------------------------------------------------------------------------------------------------------|
| The problem of                | effortlessly integrating and configuring various smart home systems and gadgets.                                            |
| Affects                       | manufacturers, developers, and homeowners in the smart home sector.                                                         |
| The impact of which is        | a decline in consumer satisfaction with smart home technologies and an increase in complexity and costs.                    |
| A successful solution would be| simplifying the development process, improving the user experience, cutting costs, and hastening the adoption of smart home technologies would all be beneficial solutions. |


## Product Postion Statement
Among the many sophisticated software tools available on the market, the Smart Home Simulator is unique in that it allows users to manage and simulate complex smart home setups. This platform is specially made for people who want to learn about smart home technologies practically as well as theoretically. It meets educational, developmental, and research demands in smart home business by providing an in-depth investigation of device interactions and behaviors within a smart home, hence filling a void in the market for comprehensive, interactive, and customisable simulation.

| Header                         | Description                                                                                                                      |
|--------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| **For**                        | Tech enthusiasts, educators, and researchers.                                                                                    |
| **Who**                        | Need a flexible platform to research and evaluate smart house technologies.                                                      |
| **The Smart Home Simulator**   | Is a comprehensive simulation software suite.                                                                                    |
| **That**                       | Provides a thorough and accurate simulation of smart home ecosystem.                                                             |
| **Unlike**                     | Less complicated teaching resources or simple simulation software.                                                               |
| **Our product**                | Offers a highly customizable, immersive, and interactive environment that promotes deep learning and innovation in smart home technology. |

## Product Overview
### Product Perspective
The Smart Home Simulator is intended to function as a stand-alone, self-contained unit. Although it can integrate with a variety of IoT and smart home devices, its fundamental operations do not rely on external systems. These systems and gadgets can communicate as they would in a user's surroundings thanks to the simulator, which offers a simulated environment. Similar to other smart home management solutions, it enables the orchestration of devices and the simulation of household interactions with IoT systems; however, what sets it apart is its focus on education and experimentation.

### Assumptions and Dependancies
| Assumptions | Dependencies |
|-------------|--------------|
| There will be sensors in all doors and windows and motion detectors in each room. | The system's security features, like alerts and mode functions, depend on these sensors. |
| The system allows users to set an “away mode”. | Notifications and automated responses rely on the system being set to this mode. |
| Multiple heating zones exist in the home, controlled by individual thermostats. | The effectiveness of the Smart Heating Module depends on the presence and functionality of these thermostats. |
| The system can detect when the house is unoccupied. | Temperature adjustments and energy savings are contingent on this occupancy detection feature |
| Notifications are sent for unusual temperature changes. | The safety and maintenance features require the system to monitor and accurately report temperature anomalies. |

#### Context Diagram
<img width="347" alt="Screenshot 2024-03-13 160430" src="https://github.com/alexsmags/TechTitans/assets/111084379/3d5d67de-448a-46a1-bdc4-07939908340f">

#### Domain Model
<img width="350" alt="image" src="https://github.com/alexsmags/TechTitans/assets/111084379/8ddc5d48-8f9d-4a73-8247-62866b71437e">




# Phase II
## Team Members and Role 

| Name                  | Role                 | ID       |
| --------------------- | -------------------- | -------- |
| Alexander Smagorinski | Use Cases/Frontend/Backend/Design Patterns                | 40190986 |
| Cosmin Suna           | Use Cases/Simulation Context Stat-machine Diagram/Backend | 40125921 |
| Mohamad Mounir Yassin | Use Cases/Simulation Context Activity Diagram/Unit Tests  | 40198854 |
| Saikou Diallo         | Use Cases/Design Patterns                                 | 40191902 |
| Patrick MacEachen     | Use Cases/Unit Testing                                    | 40209790 |


## Diagrams

### Use-case diagram for the whole system
<img width="243" alt="Screenshot 2024-03-13 154354" src="https://github.com/alexsmags/TechTitans/assets/111084379/28b0ccaa-b81e-4f48-a291-41a4674bad4f">


### Sequence diagrams for the Smart Home Core functionality (SHC) module 
<img width="261" alt="Screenshot 2024-03-13 154531" src="https://github.com/alexsmags/TechTitans/assets/111084379/8eb93176-6d26-444d-9a45-92a94e18e20b">
<img width="560" alt="Screenshot 2024-03-13 154638" src="https://github.com/alexsmags/TechTitans/assets/111084379/947c22be-f52a-4ba8-a37c-1135283dc74f">


### State-machine diagram for the Context of the Simulation
<img width="200" alt="Screenshot 2024-03-13 155207" src="https://github.com/alexsmags/TechTitans/assets/111084379/0143d54d-4cfb-453c-9948-587266d0dfa5">

### Activity diagram for Context of the Simulation
<img width="349" alt="Screenshot 2024-03-13 155656" src="https://github.com/alexsmags/TechTitans/assets/111084379/a65eabc2-fac9-4516-a19a-30dd0ef59b8e">

### Singleton Design Pattern
<img width="416" alt="Screenshot 2024-03-13 155822" src="https://github.com/alexsmags/TechTitans/assets/111084379/b77dd350-867d-4b71-8a81-7ee47bd17a45">

### Builder Design Pattern
<img width="803" alt="image" src="https://github.com/alexsmags/TechTitans/assets/111084379/281d764f-3f2a-4a0e-a4ef-1789085f83db">

### Command Design Pattern
<img width="715" alt="Screenshot 2024-03-13 160012" src="https://github.com/alexsmags/TechTitans/assets/111084379/f24219d3-fb61-47bc-8d7d-3852cf2ff02c">

# Phase III

## Team Members and Role 
| Name                  | Role                 | ID       |
| --------------------- | -------------------- | -------- |
| Alexander Smagorinski | UC 1.1 / UC 1.2 / UC 1.3 / Design Pattern | 40190986 |
| Cosmin Suna           | UC 1.6 / UC 1.7 / Updated State-machine diagram for the Context of the simulation | 40125921 |
| Mohamad Mounir Yassin | UC 1.5 / Activity Diagram for SHH module / Updated Activity diagram for Context of the simulation | 40198854 |
| Saikou Diallo         | UC 1.9 / Use-case diagram for the whole system | 40191902 |
| Patrick MacEachen     | UC 1.8 / State-machine diagram for the SHH module | 40209790 |

## Diagrams

### Use-case diagram for the whole system
 ![image](https://github.com/alexsmags/TechTitans/assets/111084379/d6200234-2077-4f43-93bf-f2910cf7a031)

### Sequence diagrams for the Smart home core functionality (SHC) module (NO CHANGE)
<img width="261" alt="Screenshot 2024-03-13 154531" src="https://github.com/alexsmags/TechTitans/assets/111084379/8eb93176-6d26-444d-9a45-92a94e18e20b">

### State-machine diagram for the Context of the simulation
![image](https://github.com/alexsmags/TechTitans/assets/111084379/fca8e772-e57e-4f05-bc7c-365c15378613)

### Activity diagram for Context of the simulation
![Screenshot 2024-03-25 180022](https://github.com/alexsmags/TechTitans/assets/111084379/27712066-1d4f-46eb-a093-c9ee7957c1ea)

### State-machine diagram for the SHH module
![image](https://github.com/alexsmags/TechTitans/assets/111084379/d2a23cb5-95c8-4ff2-95c8-e011fe9577ce)

### Activity diagram for the SHH module
![image](https://github.com/alexsmags/TechTitans/assets/111084379/1a448c8c-840e-4f4b-84f8-6c24493acde8)

# Phase IV

## Team Members and Role 
| Name                  | Role                 | ID       |
| --------------------- | -------------------- | -------- |
| Alexander Smagorinski |UC 2.1 / 2.3 / 2.4 / 2.5 / 2.7 & Design Pattern  | 40190986 |
| Cosmin Suna           | Previous UC(s) from phase III | 40125921 |
| Mohamad Mounir Yassin | State-machine diagram for the Context of the simulation / Activity diagram for Context of the simulation / State-machine diagram for the SHP module / Activity diagram for the SHP module | 40198854 |
| Saikou Diallo         | Review UC | 40191902 |
| Patrick MacEachen     | Sequence diagram for SHP /Updated System Use Case Diagram / UC 2.4 | 40209790 |

## System Architecture

For the Home Simulator Application, we will be using the Model-View-ViewModel			(MVVM) architectural pattern. Therefore, we will need to use the following 3 layers
	UI Layer, Application Layer, and Domain Layer.

 <br/>
 
![image](https://github.com/alexsmags/TechTitans/assets/111084379/9eac0912-264c-419c-88ad-8fcc52f8bb8c)

## Use Case Models
### Smart home security (SHP) Module
UC2.1

![image](https://github.com/alexsmags/TechTitans/assets/111084379/8c460fdf-cde4-4197-a510-49fb7eba1ee5)

UC2.2

![image](https://github.com/alexsmags/TechTitans/assets/111084379/ed4b24cd-f982-437d-880e-563a4c3d48ff)

UC2.3

![image](https://github.com/alexsmags/TechTitans/assets/111084379/ea085499-9ac9-407d-814a-256465847edb)

UC2.4

![image](https://github.com/alexsmags/TechTitans/assets/111084379/1c1de2df-e638-494b-87fe-4e876ff0b0ca)

UC2.5

![image](https://github.com/alexsmags/TechTitans/assets/111084379/3a74704b-58a0-4594-acfd-29331e1701ea)
![image](https://github.com/alexsmags/TechTitans/assets/111084379/8aef4455-a78a-465c-b05a-ce1625d8f59c)

UC2.6

![image](https://github.com/alexsmags/TechTitans/assets/111084379/c8f7bc87-df4a-46b4-80c8-61427ece9d8d)

UC2.7

![image](https://github.com/alexsmags/TechTitans/assets/111084379/9a3a1826-12e5-4522-be18-ced67f593cb7)


## Diagrams

### Use-case diagram for the whole system
![image](https://github.com/alexsmags/TechTitans/assets/111084379/c6e676f4-dd4a-4740-9a93-717ccfc28638)


### Sequence diagrams for the Smart home core functionality (SHC) module
![image](https://github.com/alexsmags/TechTitans/assets/111084379/2cb685c9-de19-455c-9bef-1ee31ea742fd)

### State-machine diagram for the Context of the simulation
![image](https://github.com/alexsmags/TechTitans/assets/111084379/d76755e6-3b63-40de-a040-e493c92d5b2e)

### Activity diagram for Context of the simulation
![image](https://github.com/alexsmags/TechTitans/assets/111084379/5a0f34b6-00e7-40ba-b20e-f04c9ff4927e)

### State-machine diagram for the SHP module
![image](https://github.com/alexsmags/TechTitans/assets/111084379/79c28467-6ee2-4691-b42c-77284ef4c5cb)


### Activity diagram for the SHP module
![image](https://github.com/alexsmags/TechTitans/assets/111084379/8d47f25f-1d8a-4fb0-b4f2-d4316bf4e615)

### Design Patterns
![image](https://github.com/alexsmags/TechTitans/assets/111084379/25830156-d82e-4cb7-b0d8-3248779314c6)

