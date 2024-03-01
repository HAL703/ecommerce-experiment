"use client";
import {lazy, Suspense} from 'react';
import './App.css';
import { ErrorBoundary } from "react-error-boundary";
const Register = lazy(() => import("./Register.tsx"));
//const UserList = lazy(() => import('./UserList.tsx'));

function App() {
    // function MyErrorBoundaryFallback({ errorMessage, errorStatus }: ErrorBoundary) {
    //     return (
    //         <div className="container">
    //             <h1>Error</h1>
    //             <div className="row">
    //                 Error Status: <b>{errorStatus}</b>
    //             </div>
    //             <div className="row">
    //                 ErrorMessage: <b>{errorMessage}</b>
    //             </div>
    //         </div>
    //     );
    // }

    // function fallbackRender({ error, resetErrorBoundary }) {
    //     // Call resetErrorBoundary() to reset the error boundary and retry the render.
    //
    //     return (
    //         <div role="alert">
    //             <p>Something went wrong:</p>
    //             <pre style={{ color: "red" }}>{error.message}</pre>
    //         </div>
    //     );
    // }
    return (
        <>
            <div>
                <h1 id="tableLabel">User List</h1>
                <p>This component demonstrates fetching data from the server.</p>
                <ErrorBoundary fallback={<div>error</div>}>
                    <Suspense fallback={<div>Loading users...</div>}>
                        {/*<UserList />*/}
                    </Suspense>
                    <Suspense fallback={<div>Loading registration...</div>}>
                        <Register />
                    </Suspense>
                </ErrorBoundary>
            </div>
        </>
    );
}

export default App;