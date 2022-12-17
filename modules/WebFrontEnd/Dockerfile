### STAGE 1: Build ###
FROM node:16.17 AS build
WORKDIR /usr/src/app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build-prod

### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
#RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /usr/src/app/dist/web-app /usr/share/nginx/html
#CMD ["nginx", "-g", "daemon off;"]
