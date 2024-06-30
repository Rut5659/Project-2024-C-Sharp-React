import { RouterProvider } from "react-router-dom";
import { router } from "./routes/router";
import { Provider } from "react-redux";
import { store } from "./redux/store";
import InitializeAuth from "./auth/InitializeAuth";

function App() {
  return (
    <Provider store={store}>
      <InitializeAuth>
        <RouterProvider router={router} />
      </InitializeAuth>
    </Provider>
  );
}

export default App;
