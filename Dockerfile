FROM mcr.microsoft.com/dotnet/core/sdk:2.2

LABEL maintainer="dhayanidhi.jr@gmail.com"

RUN apt-get update \
 && DEBIAN_FRONTEND=noninteractive apt-get install -y mysql-server

COPY entrypoint.sh /sbin/entrypoint.sh

RUN chmod 755 /sbin/entrypoint.sh

WORKDIR /app

COPY ./ .

CMD ["/sbin/entrypoint.sh"]
