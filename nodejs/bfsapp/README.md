Sample nodejs project.  
It has been containerized

To build the Docker container and run it:
1. From the root folder of the project type: docker build -t bfsapp:latest .
2. To execute it type: docker run -p 3000:3000 -d bfsapp:latest
3. Open browser to: http://dockerhost:3000/bfs or http://dockerhost:3000/ or http://dockerhost:3000/users

