import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import CargoLoadManagement from "./components/CargoLoadManagement";
import ExportCargoLoads from "./components/ExportCargoLoads";
import Navbar from "./components/Navbar";
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<CargoLoadManagement />} />
        <Route path="/export" element={<ExportCargoLoads />} />
      </Routes>
    </Router>
  );
}

export default App;
