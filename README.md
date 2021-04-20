# dotnet-core-flicker-project-server
This project consists in a simple proxy API to [Flickr Data Feed](https://www.flickr.com/services/feeds/) public API. The idea here is to follow the [SOLID](https://www.digitalocean.com/community/conceptual_articles/s-o-l-i-d-the-first-five-principles-of-object-oriented-design) principles and the `dotnet core` patterns as an exercise.

# API

## [GET] Feed
`http://localhost:4040/api/Feed?tags=nature,space`

This endpoint is responsible to serve the Flickr images filtered by the tags.

### Flickr Endpoint
`https://www.flickr.com/services/feeds/photos_public.gne?format=json&tags=nature,space`

# Future Work
There are some features missing that were not implemented due the time available. It would be nice to have a Distributed Cache System implemented on Redis and also identify some points to improve the usage of the SOLID principles.

# Swagger
This tool is a powerful hanging fruit. It auto-generates an API documentation based on annotations and endpoint signatures. It is awesome, it is possible to access a frontend auto-generated to view the documentation.

After running the docker, the swagger will be served at: `http://localhost:4040/swagger/index.html`

# Running with Docker
Run these commands at the root project folder:
### building the image
`docker build --pull --rm -f "dockerfile" -t dotnetcoreflickerprojectserver:latest "."`
### running the image
`docker run --rm -it  -p 4040:4040/tcp dotnetcoreflickerprojectserver:latest`