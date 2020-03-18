# Sabv - SellAndBuyVehicles
Sabv is a multipage application build entirely on the latest .NET technologies such as ASP.NET Core 3.x & Entity Framework Core as a project for university 
course ASP.NET Core. The main purpose is to provide user-friendly web platform where users can browse different posts containing information about vehicles
according to their needs. The application have chat where users can chat with each other, comments on posts and administration.
There are four roles - guest, registered user, admin, moderator. The guest can only browse through the posts but in order to create one he 
should register or login into existing account. The already logged in user can browse, create posts, add other posts to his favourites, track his own post status
etc. The moderator can delete chat messages, comments and can do everything that a regular user can. Admin is the same as moderator, but he can also delete posts.

## Frameworks and services used
```
SignalR
SendGrid
Cloudinary
CloudscribePagination
.NET Core 3.1
.EF Core
```

## The app should launch your default browser and open the website. But if it dont, go to 
```
localhost:5000
```

## Important
```
The app is filled with some sample data, the car models and makes wont be relevant. The seeding methods are using
random values from Db to create fake posts and show the potential of the website.
```

![HomePage](https://user-images.githubusercontent.com/44707978/76702090-ac1bfc00-66cf-11ea-8f6e-2e640271462f.PNG)
![DetailsPage](https://user-images.githubusercontent.com/44707978/76702104-c5bd4380-66cf-11ea-8c3d-4774b8fb9061.PNG)
![AboutPage](https://user-images.githubusercontent.com/44707978/76702107-ce157e80-66cf-11ea-8ac9-8f04b281a858.PNG)
![CategoryPage](https://user-images.githubusercontent.com/44707978/76702109-d53c8c80-66cf-11ea-9857-ee1193eb4cae.PNG)
![ChatPage](https://user-images.githubusercontent.com/44707978/76702110-dc639a80-66cf-11ea-96bb-31e6c75f05ef.PNG)
![CreatePage](https://user-images.githubusercontent.com/44707978/76702113-e38aa880-66cf-11ea-9a68-5be8f4f5bd60.PNG)
![SearchPage](https://user-images.githubusercontent.com/44707978/76702123-fef5b380-66cf-11ea-9d18-e7bf901a07d9.PNG)
![AllPage](https://user-images.githubusercontent.com/44707978/76702127-07e68500-66d0-11ea-933a-29ba39954845.PNG)
