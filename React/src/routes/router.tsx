
import { Navigate, createBrowserRouter } from 'react-router-dom';
import LoginPage from '../pages/LoginPage';
import HomePage from '../pages/HomePage';
import { PATHS } from './paths';
import Layout from '../layouts/MainLayout';
import AuthGuard from '../auth/AuthGuard';
import GuestGuard from '../auth/GuestGuard';

export const router = createBrowserRouter([
    {
        path: PATHS.home,
        element: <AuthGuard><Layout /></AuthGuard>,
        children: [
            {
                path: '',
                element: <HomePage />,
            },
            {
                path: 'about',
                element: <h1>About</h1>,
            },

        ],
    },
    {
        path: PATHS.login,
        element: <GuestGuard><LoginPage /></GuestGuard>,
    },
    {
        path: '/',
        element: <Navigate to={PATHS.home} />,
        index: true
    },
    {
        path: '*',
        element: <h1>404</h1>
    },
]);
