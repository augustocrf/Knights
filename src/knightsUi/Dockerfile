# Usar a imagem oficial do Node.js para construir a aplicação
FROM node:16 as build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

# Usar a imagem do Nginx para servir a aplicação
FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80