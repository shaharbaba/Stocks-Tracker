FROM ubuntu:trusty AS ubuntu-dotnet
WORKDIR /install
# Install dotnet
RUN sudo apt-get install -y curl
RUN curl -LJO https://dot.net/v1/dotnet-install.sh
RUN chmod +x ./dotnet-install.sh
RUN ./dotnet-install.sh --channel 5.0 
RUN export PATH=/root/.dotnet:$PATH


FROM ubuntu-dotnet AS base 
WORKDIR /
RUN apt-get update; apt-get clean

# Install x11vnc.
RUN apt-get install -y x11vnc

# Install xvfb.
RUN apt-get install -y xvfb

# Install fluxbox.
RUN apt-get install -y fluxbox

# Install wget.
RUN apt-get install -y wget

# Install wmctrl.
RUN apt-get install -y wmctrl

# Set the Chrome repo.
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list

# Install Chrome.
RUN apt-get update && apt-get -y install google-chrome-stable


FROM ubuntu-dotnet AS build
WORKDIR /src
COPY ["project/project.csproj", "project/"]
RUN dotnet restore "project/project.csproj"
COPY . .
WORKDIR "/src/project"
RUN dotnet build "project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "project.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "project.dll"]
