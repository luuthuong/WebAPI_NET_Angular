FROM node:16 as build

WORKDIR /usr/local/app

#Add the source code to app
COPY ./ /usr/local/app

#install the dependencies
RUN npm install

#Generate the build of the application 

RUN npm run build

FROM nginx:lastest

COPY --from=build /usr/local/app/dist/web-app /usr/share/nginx/html

EXPOSE 80