# ArcTouch Demo App

This is the App created for the MOBILE DEV CODE CHALLENGE.

![alt text](https://github.com/jbravobr/Assets/blob/master/Android_Capture.gif?raw=true "Android's capture")
![alt text](https://github.com/jbravobr/Assets/blob/master/iOs_Capture.gif?raw=true "iOS's capture")

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Prerequisites

It is  important to have the latest version of Xcode and also installed the **ANDROID SDK PLATFORM TOOLS 25.0.4** and the **Android SDK (API 23)** and / or **Android 7 (API 24)**. Preferably API 23.  

## Installing 

```
Clone this repository and open the solution using either Xamarin Studio (preferably) or Visual Studio 2015 or 2107 (both with the Xamarin tools installed and updated by the STABLE channel)
```
## Show some screens

![alt text](https://github.com/jbravobr/Assets/blob/master/Android_MovieList.png?raw=true "Android's capture")
![alt text](https://github.com/jbravobr/Assets/blob/master/Android_DetailsPage.png?raw=true "Android's capture")


![alt text](https://github.com/jbravobr/Assets/blob/master/iOS_MovieList.png?raw=true "iOS's capture")
![alt text](https://github.com/jbravobr/Assets/blob/master/iOs_DetailsPage.png?raw=true "iOS's capture")

## Third-party components (plug-ins via nuget and direct install)

These were the main plug-ins used

| Plug-ins|
| ------------------- |
|SyncFusion Rating Control|
|Prism Library|
|FFImageLoading|
|sqlite-net-pcl|
|SQLite Extensions|
|Xamarin Connectivity Plugin|
|PropertyChanged|
|Airbnb Lottie|
|Acr UserDialogs|
|Acr Settings|

### SyncFusion Rating Control

Syncfusion provides a range of controls for Xamarin. For this App we use the rating control, in the format of stars to display the average rating of the movies
[For more information access here](https://help.syncfusion.com/xamarin/sfrating/overview)

### Prism Library

We used the Prism library to improve the native MVVM features of the Xamarin Forms library and have better control and performance over the navigation within the App. In addition to decreasing the coupling in the App, allowing us greater testability
[For more information access here](https://github.com/PrismLibrary/Prism)

### FFImageLoading

We use the FFImageLoading plug-in for greater agility and flexibility in working with images, allowing us to treat simpler blur and the possibility of working with cache
[For more information access here](https://github.com/luberda-molinet/FFImageLoading)

### sqlite-net-pcl

We use the sqlite-net-pcl plug-in as the database system orchestrator for the app. Thinking of adding more value to the solution, we introduce concepts of offline data, making us use this solution to achieve this
[For more information access here](https://github.com/praeclarum/sqlite-net)

### SQLite Extensions

We use the SQLite Extensions plug-in as a way of maintaining a healthy relationship between possible entities in our app. Thus, no schema changes in the database, we can persist and retrieve full form of information and related
[For more information access here](https://bitbucket.org/twincoders/sqlite-net-extensions)

### Xamarin Connectivity Plugin

We use the Xamarin Connectivity Plugin plug-in to give us the flexibility to access the connectivity features of both platforms via PCL
[For more information access here](https://github.com/jamesmontemagno/ConnectivityPlugin)

### PropertyChanged (Fody)

We use the PropertyChanged plug-in to make it easier to use "Auto-observable" properties through the INotifyPropertyChanged interface and thus keep the MVVM standard more fluid
[For more information access here](https://github.com/Fody/PropertyChanged)

### Airbnb Lottie

We use the Airbnb Lottie plug-in (iOS only) to bring and exemplify how we can work with animations in a practical and performative way using Xamarin Forms
[For more information access here](https://github.com/martijn00/LottieXamarin)

### Acr UserDialogs

We use the Acr UserDialogs plug-in to work with displaying alerts and personalized messages in a simple way through the PCL project
[For more information access here](https://github.com/aritchie/userdialogs)

### Acr Settings

We use the Acr Settings plug-in so that we can access key-value based storage resources, platform standards
[For more information access here](https://github.com/aritchie/userdialogs)

## Built With

* [Xamarin Forms](https://www.nuget.org/packages/Xamarin.Forms/) - Xamarin Forms (Last Stable Version)
* [Mono](http://www.mono-project.com/docs/about-mono/releases/4.8.0/) - Mono (Last Stable Version)

## Authors

* **Rodrigo Amaro**

## License

This project is licensed under the MIT License 
