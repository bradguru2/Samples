This is an Anagram Service created using .NET Core 2.0 Web Api technology.

The editor used for this project is Visual Studio Code.

Usage example:
curl http://0.0.0.0:8080/api/anagrams/bedroom  (or simply open up in browser)
["boerdom","boredom","broomed"]

Please be aware that I *borrowed* the file, "words.txt", from:
https://github.com/dwyl/english-words.git

For Docker fans, a Docker file has been provided.  It will deploy the source to 
a tmp container and build it creating an image.  This method was chosen for 
cross-platform compatibility.  The image is larger but it will work on either
Windows or Linux containers and can be developed on a Mac (if desired).

Docker command to build the image:
docker build -t anagram:latest .

Docker command to create the container:
docker container create --name anagram -p 8080:8080 anagram:latest

Docker command to start the container:
docker container start anagram

Enjoy!