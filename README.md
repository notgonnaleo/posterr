# Tech Stack
  # Backend:
    - .NET 6
    - MediatR (for decoupled request handling)
    - EF Core (for ORM support)
    - Dapper (for lightweight, efficient SQL queries)
  
  # Database:
    - PostgreSQL: Chosen for its lightweight nature and availability of free hosting services.
  
  # Frontend:
    - React with TypeScript (for type safety and efficient UI development)
    - Vite (for fast, modern builds)
    - Material-UI (for polished, customizable UI components)

# How to Run 
  # API Project: (\Posterr\src\posterr-services\posterr-posting-service)
  1. Open the Posting.API.sln solution in your IDE. 
  2. Ensure that the migrations folder is populated. Run the following command to apply database migrations:
      - dotnet ef database update
  (Note: The output folder for migrations is Posting.Infrastructure, and the start project should be set to Posting.API).
  1. Press F5 or click the Start button in your IDE to run the API project.
  2. The API services should now be up and running. (Expect an browser page with Swagger)
   
  # UI Project: (\repos\Posterr\src\posterr-ui)
    1. (Ensure you're using the latest versions of Node and npm, with Vite for fast bundling.)
    2. Open the posterr-ui folder in your terminal or code editor.
    3. Install dependencies with:
        - npm install
    4. Start the development server with:
        - npm run dev
    5. You should be able to access it at http://localhost:5173 (Vite default port)

# How to run
1. For the API project;
2. Open the Posting.API.sln;
3. Check if the migrations folder is not empty and run "dotnet ef database update"; (The output folder is the Posting.Infrastructure and the start project should Posting.API);
4. Press F5 (or click the start button);
5. the API services should be up and running;
6. For the UI project:
7. Open the posterr-ui folder;
8. Run npm i;
9. Run npm run dev;
(Using latest node and npm version with vite)

# Critique

* Project Overview
The app is in a solid state, with core features like reposts, post creation, filter selection, and keyword search fully implemented. 
Given more time, my focus would be on refining the app’s UI components to match my original design vision and eliminating any unused code or logic that might have accumulated over time. 
This would allow the app to reach its full potential, running smoother and cleaner. 
A full codebase cleanup and adaptation would be my top priority, ensuring everything is in its best shape for long-term success.

* Scaling for Growth
In terms of scaling, we’ve already implemented good performance practices, such as paginating posts on the UI. 
On the backend, we use the MediatR pattern, combined with EFCore and Dapper, which allows us to execute SQL queries directly for more efficient data retrieval—avoiding unnecessary database calls. 
MediatR provides excellent decoupling, and it serves as a solid foundation for future migration into a full CQRS architecture.
The overall app structure, architecture, and folder organization align perfectly with my initial vision, and I wouldn’t change a thing there. 
However, to push performance further, I’d implement background job processing with Hangfire and RabbitMQ Queues to handle Post and Repost operations more efficiently. 
With potential load balancers in place, we could ensure that our app scales effortlessly without bottlenecks during high traffic periods.
In hindsight, while the app was designed to be scalable in just one week, it’s important to acknowledge that development isn’t always perfect. 
Bugs are part of the journey, and with more time, I could’ve enhanced the app further, potentially introducing a robust state management system (like Redux or React Context API) to support user profiles and authentication cache data.

* Challenges and Lessons Learned
Reflecting on the development process, I’m confident that the code follows best practices, and despite some challenges, the result is something I’m proud of. The main struggles were around the UI, particularly with React, which introduced some complexities. Below are two key issues I encountered:

1. Dynamic Scrolling (InteractObserver)
What happened:
I initially tried to implement a dynamic scrolling feature like Twitter’s Infinite Scroll using the IntersectionObserver API. Unfortunately, the implementation triggered multiple API calls and didn’t behave as expected, so I had to switch to a more conventional "Load More" button on the feed.

How I would solve it with more time:
If I had more time, I would revisit this feature, giving it priority from the start. I would spend more time adjusting the UI structure and stylesheets (Because it rely on the page viewport) to ensure that the IntersectionObserver functions correctly. Properly tackling this challenge would allow us to improve the user experience with more efficient scrolling.

2. React Component State and Filter Handling
What happened:
When the filter is changed, React’s state management caused issues with the re-rendering of the posts list due to the pagination system. Although the backend returns the updated data, the UI struggles to reflect the changes.

How I would solve it with more time:
With the IntersectionObserver fully implemented, I’d likely avoid running into this issue. But if it persists, my solution would be to split the posts list into two components. One component would handle the pagination, while the other could manage the filter updates—ensuring the UI can properly re-render when necessary.

Overall, I believe the app is in a solid place, with clear opportunities for improvement if given more time. By focusing on polishing the UI, resolving the above challenges, and introducing additional performance enhancements, this project could evolve into an even more scalable and seamless experience for users.