import * as React from 'react';
import 'reflect-metadata';
import {
    BrowserRouter,
    Route,
    Routes
} from 'react-router-dom';

import './app.css';
import { AppProvider } from './global/provider';
import AppBar from './views/layout/AppBar';
import ProjectsListView from './views/project/ProjectsListView';
import { ToastContainer } from './core/components/toastify/Toastify';
import { ProjectDetailsView } from './views/project/detail/ProjectDetailsView';

export default function App() {
    return (
        <AppProvider>
            <section>
                <AppBar />
                <BrowserRouter>
                    <Routes>
                        <Route path="/projects/:projectId" element={<ProjectDetailsView />} />
                        <Route path="/projects" element={<ProjectsListView />} />
                        <Route path="/" element={<ProjectsListView />} />
                    </Routes>
                </BrowserRouter>
                <ToastContainer />
            </section>
        </AppProvider>
    );
}
