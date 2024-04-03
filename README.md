# Manto
The acronym of this project name is for management tool. 

## Project overview
I wanted to build a project that would showcase most of my programming experience/skills, and that in the future could be useful for me to build other projects, so I decided to build a management tool. 

The project will have the following *architecture/practices/tools/frameworks/etc*: 
* Microservices architecture. 
* Git branching strategy.
* S.O.L.I.D
* Design patterns.
* REST API standards.
* OWASP
* JWT
* .NET 8 (web API, Signal R)
* Angular 17.
* Unit testing.
* CI/CD
* DBMS

### Microservices architecture
Previously I have built microservices in teams of 3 - 4 programmers, where usually every developer was in charge of at least one microservice. So I have experience building microservices and I know which NO functional requirements it offers, for example scalability. Later on I will write more on why I choose this architecture.  

### Branching strategy
All microservices will be host in a single Github repository, this is known in the IT industry as mono-repo. In my case I choose mono-repo because im a single person working on the whole project, so it will be easiear to handle and also to deploy changes. 
The Git branching strategy that I will use is called GitHub flow, where the main branch is always production-ready, and changes to this trigger the CI/CD process.


### .NET 8 (.NET Core)
I Choose to use **.NET 8** because it offers Long term support (LTS) for development and also brings the support for the new C# 12, which brings new simplified sintaxis and improvements to performance. The project templates that I will use are: 
* ASP.NET Core - Web API


### CI/CD
One of the most useful things to streamline software development is the ability to automate workflows/human processes. This project will use Github actions to automate continuous integration and continuous delivery commonly known as CI/CD pipeline.
To track the current state of Github actions use 
* https://www.githubstatus.com/ 

#### Continuous Integration
The continuous integration process will trigger everytime the main branch receives a pull request from a feature branch, activating the following workflows:
* Build
* Test

#### Continuous Deployment
Once the administrator validates that the build and test from the pull request are successful, he can merge the feature into the main branch. Once the main branch receives the merge, github actions will automatically trigger the CD pipeline, activating the following workflows:
* Deploy 
* Run