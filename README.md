# TechTitans
This repo contains the code for the Smart Home Simulator done for the SOEN343 course


## Team Members and Role - Phase I

| Name                  | Role                 | ID       |
| --------------------- | -------------------- | -------- |
| Alexander Smagorinski |Making Context Diagram/Review| 40190986 |
| Cosmin Suna           | Making Domain Model/Review  | 40125921 |
| Mohamad Mounir Yassin |    Documentation/Review     | 40198854 |
| Saikou Diallo         | Making Domain Model/Review  | 40191902 |
| Theodore Ku           |Making Context Diagram/Review| 40191463 |
| Patrick MacEachen     | Making Domain Model/Review  | 40209790 |


# Problem Definition
## Problem Statement:
The intricacies and difficulties associated with programming smart home systems are tackled by  the Smart Home Simulator project. It seeks to offer a way to coordinate different linked gadgets in a smart home setting. The simulator concentrates on addressing problems that are common to programming tasks for smart home automation, such as feature interaction, modularity, debugging, and comprehension. The project makes it easier to experiment with and find solutions for these programming issues by providing a graphical depiction of the interactions between household gadgets and IoT systems. This increases the efficacy and efficiency of developing and deploying smart home systems.

| 1                             | 2                                                                                                              |
|-------------------------------|------------------------------------------------------------------------------------------------------------------------------|
| The problem of                | effortlessly integrating and configuring various smart home systems and gadgets.                                            |
| Affects                       | manufacturers, developers, and homeowners in the smart home sector.                                                         |
| The impact of which is        | a decline in consumer satisfaction with smart home technologies and an increase in complexity and costs.                    |
| A successful solution would be| simplifying the development process, improving the user experience, cutting costs, and hastening the adoption of smart home technologies would all be beneficial solutions. |


## Product Postion Statement:
Among the many sophisticated software tools available on the market, the Smart Home Simulator is unique in that it allows users to manage and simulate complex smart home setups. This platform is specially made for people who want to learn about smart home technologies practically as well as theoretically. It meets educational, developmental, and research demands in smart home business by providing an in-depth investigation of device interactions and behaviors within a smart home, hence filling a void in the market for comprehensive, interactive, and customisable simulation.

\| Header                         | Description                                                                                                                      |
|--------------------------------|----------------------------------------------------------------------------------------------------------------------------------|
| **For**                        | Tech enthusiasts, educators, and researchers.                                                                                    |
| **Who**                        | Need a flexible platform to research and evaluate smart house technologies.                                                      |
| **The Smart Home Simulator**   | Is a comprehensive simulation software suite.                                                                                    |
| **That**                       | Provides a thorough and accurate simulation of smart home ecosystem.                                                             |
| **Unlike**                     | Less complicated teaching resources or simple simulation software.                                                               |
| **Our product**                | Offers a highly customizable, immersive, and interactive environment that promotes deep learning and innovation in smart home technology. |

## Product Overview:
### Product Perspective:-
The Smart Home Simulator is intended to function as a stand-alone, self-contained unit. Although it can integrate with a variety of IoT and smart home devices, its fundamental operations do not rely on external systems. These systems and gadgets can communicate as they would in a user's surroundings thanks to the simulator, which offers a simulated environment. Similar to other smart home management solutions, it enables the orchestration of devices and the simulation of household interactions with IoT systems; however, what sets it apart is its focus on education and experimentation.

### Assumptions and Dependancies:-
| Assumptions | Dependencies |
|-------------|--------------|
| There will be sensors in all doors and windows and motion detectors in each room. | The system's security features, like alerts and mode functions, depend on these sensors. |
| The system allows users to set an “away mode”. | Notifications and automated responses rely on the system being set to this mode. |
| Multiple heating zones exist in the home, controlled by individual thermostats. | The effectiveness of the Smart Heating Module depends on the presence and functionality of these thermostats. |
| The system can detect when the house is unoccupied. | Temperature adjustments and energy savings are contingent on this occupancy detection feature |
| Notifications are sent for unusual temperature changes. | The safety and maintenance features require the system to monitor and accurately report temperature anomalies. |

##Domain Model
![alt text](https://cdn.discordapp.com/attachments/1199789503007690815/1205263740405153864/SOEN343DomainModel.jpg?ex=65d7bc54&is=65c54754&hm=35180d3d57c21b00e1b70157a44494fc70cded5d60d3da733824a12583dcac7f&)

