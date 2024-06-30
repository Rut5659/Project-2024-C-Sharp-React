import { Navigate, createBrowserRouter } from 'react-router-dom';
import Layout from './Layout';
import Post from './Post';
import { getPostById } from '../Lesson_12/services/post.service';
import Login from './Login';

export const router = createBrowserRouter([
  {
    path: '/home',
    element: <Layout />,
    children: [
      {
        path: '',
        element: <h1>Home</h1>,
      },
      {
        path: 'about',
        element: <h1>About</h1>,
      },
      {
        path: 'products',
        element: <h1>Products</h1>,
      },
      {
        path: 'post/:id',
        element: <Post />,
        loader: async ({ params }) => {
          const post = await getPostById(Number(params.id!));
          return post;
        },
        errorElement: <h1>Load Post Data Failed</h1>,
      },
    ],
  },
  {
    path: '/',
    element: <Login />,
  },
  // {
  //     path: '*',
  //     element: <h1>404</h1>
  // },
  {
    path: '*',
    element: <Navigate to='/' />,
  },
]);
