#### COMANDOS PARA PUBLICAR
#
# 
# PRODUÇÃO
# docker build -t nettofranco91/mmn_v2:production .
# docker push nettofranco91/mmn_v2:production
# https://$atlantic-wonder:qlzqXs51ngC7lvXC5kMB8g6X84hdRrCtRF2bmp8Aqr3AEqz1GX03lh7qpyKx@atlantic-wonder.scm.azurewebsites.net/docker/hook
#
# HOMOLOGAÇÃO
# docker build -t nettofranco91/mmn_v2:homol .
# docker push nettofranco91/mmn_v2:homol


FROM node
RUN npm install -g http-server
WORKDIR /app

COPY package*.json ./
COPY .env ./

RUN npm install
COPY . .
RUN npm run build

EXPOSE 8080
CMD [ "http-server", "dist" ]
