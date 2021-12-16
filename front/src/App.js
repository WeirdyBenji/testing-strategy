import Feed     from "./Feed/Feed";
import Login    from "./Login/Login";
import Register from "./Register/Register";
import NoPage   from "./NoPage/NoPage";
import "./App.css";

import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route index element={<Feed />} />
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="*" element={<NoPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
