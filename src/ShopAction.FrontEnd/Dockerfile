FROM node:15.6.0-alpine3.10 AS compile-image
WORKDIR /opt/ng 
RUN yarn install

ENV PATH="./node_modules/.bin:$PATH" 
COPY ./store ./ 
RUN ng build --prod

FROM nginx:alpine
COPY --from=compile-image /opt/ng/dist/store /usr/share/nginx/html