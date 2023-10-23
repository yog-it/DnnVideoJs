---
---

# Getting Started

## Installation
1. Download the latest version of the package from the [releases page](https://github.com/yog-it/DnnVideoJs/releases).
1. Login to your DNN instance as the Host user and go to the **Host > Extensions** section of the PersonaBar.
![Extensions section of the PersonaBar](/images/fig1.jpg)
1. Select the **Install Extension** button and upload the zip file you downloaded in the previous step.
![Install Extension button](/images/fig2.png)
1. Go through the steps and install the extension.
1. Go to a page on your site and add the **VideoJs** module to the page.
![add the VideoJs module to the page](/images/fig3.png)
![drop the module in a pane on the page](/images/fig4.png)
1. Select "Edit Video" from the module settings drop down menu.
![add the VideoJs module to the page](/images/fig5.png)
1. Enter the title of the video.
1. Select the poster image for the video or upload a new poster image.  This is optional, if left blank the player will be a blank black screen with the play button in the middle.
1. Select the video file to play.  This can be a local file or a file from the file manager. You may need to configure your DNN instance to accept large file uploads.								
1. Select the close captioning file to use.  This can be a local file or a file from the file manager. As of version 1.0, only .vtt files are supported. This is optional, if left blank no close captioning will be used. If you are using .vtt files, you will most likely need to allow them to be uploaded to the file system (see "Allow .vtt File Type" section below).
![Edit video page](/images/fig6.png)
1. Click Update.
1. Enjoy!

## Settings
The module settings has three check boxes. 
- The first box is for "Play from Folder". Use this feature to play videos from a directory using their files names.  For instance, you can place the module on a page named "Videos" and using this feature can use https://www.yourdomain.com/Videos/Play/{filename without extension}/  to watch videos.  These feature will set the module to read the files from the folder and will ignore the video information entered into the Edit Video form.
- The second option is "Play in full screen mode automatically" and is self explanitory.  When checked the video will open in full screen.  Automatic playback is not set because that setting causes issues with browsers automatically muting the video is auto played.
- The third option is for "Display as page background". Use this feature to load the video as a background to the page.  This feature mutes the video upon play because most devices don't allow auto play and audio at the same time.

## Allow .vtt File Type
1. Select the Host --> Security section from the Persona Bar
![Host > Security in Persona Bar](/images/fig7.png)
1. Select the "More" tab.
1. Add ",vtt" to the Allowable File Extensions if you are allowing Admins to upload the .vtt files.  Add ",vtt" to the Default End User Extension Whitelist if you are going to allow other users besides admins to upload. 
![Host > Security > More settings](/images/fig8.png)
1. Click "Save" at the bottom

## Increase Max File Size for Uploads
The max file size of DNN by default is only 20MB which is not usually enough for videos.  You can increase the upload size by [following these directions](https://docs.dnncommunity.org/content/tutorials/troubleshooting/ts-how-to-increase-max-upload-file-size/index.html).