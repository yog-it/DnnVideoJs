# DnnVideoJS
Play Videos in DNN with [VideoJS](https://github.com/videojs/video.js)
- Embed videos into your site with video.js
- Include Close Captioning
- Works with Azure Storage connection

## Installation

1. Download the latest version of the package from the [releases page](https://github.com/yog-it/DnnVideoJs/releases).
1. Login to your DNN instance as the Host user and go to the **Host > Extensions** section of the PersonaBar.
1. Select the **Install Extension** button and upload the zip file you downloaded in the previous step.
1. Go through the steps and install the extension.
1. Go to a page on your site and add the **VideoJs** module to the page.						
1. Select "Edit Video" from the module settings drop down menu.
1. Enter the title of the video.
1. Select the poster image for the video or upload a new poster image.  This is optional, if left blank the player will be a blank black screen with the play button in the middle.
1. Select the video file to play.  This can be a local file or a file from the file manager. You may need to configure your DNN instance to accept large file uploads.								
1. Select the close captioning file to use.  This can be a local file or a file from the file manager. As of version 1.0, only .vtt files are supported. This is optional, if left blank no close captioning will be used.
1. Click Update.
1. Enjoy!

[Full documentation here](https://yog-it.github.io/DnnVideoJs/)

## Development Setup
To clone this repository, first setup the scaffolding.  It uses [@UpendoVentures](https://github.com/UpendoVentures) yeoman generator-upendodnn.  To run it, install yeoman `npm install -g yo`. Then install Yarn `npm install -g yarn`. And finally, install the generator `npm install -g generator-upendodnn`. 

Generate the scaffold in a folder for the project with `yo upendodnn`. Select Solution Structure from the list and answer the questions.  Once complete, go to the Modules folder and clone this repo there `git clone https://github.com/yog-it/DnnVideoJs.git`. Optionally install the latest version of DNN into the Website folder of the scaffold. 

To compile and create the install package, open the Visual Studio project and build in release.  The install package will be in the /Website/Installs/Module folder along with a "symbols" package for debugging.  If DNN is installed in the Website folder the package will be available to install from persona bar Settings > Extensions and select Available Extensions.

## Release Notes
### Version 1.0.0
	- Initial Release

### Version 0.2.1-beta
	- Fixed file URL not loading from the File Manager instance for Folder Providers
	- Added Caching

### Version 0.2.0-beta
	- Allow close captioning text tracks for .vtt files

### Version 0.1.0-beta
	- Setting for playing the video as a background
	- Setting for playing videos from a portal folder
	- Setting for playing the video automatically in full screen

### Version 0.0.0-beta
	- Initial Beta Release
	- Add a video
	- Play the video
	- Enjoy

