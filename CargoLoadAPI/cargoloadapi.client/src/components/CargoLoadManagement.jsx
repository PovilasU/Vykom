import React, { useState, useEffect } from "react";
import axios from "axios";
import Modal from "react-modal";
import "bootstrap/dist/css/bootstrap.min.css";

Modal.setAppElement("#root");

function CargoLoadManagement() {
  const [cargoLoads, setCargoLoads] = useState([]);
  const [newLoad, setNewLoad] = useState({
    driverName: "",
    vehicleNumber: "",
    vehicleType: "truck",
    loadWeight: "",
    isDangerousGoods: false,
  });
  const [modalIsOpen, setModalIsOpen] = useState(false);

  useEffect(() => {
    fetchCargoLoads();
  }, []);

  const fetchCargoLoads = async () => {
    const response = await axios.get("https://localhost:7028/api/cargoloads");
    setCargoLoads(response.data);
  };

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewLoad((prevLoad) => ({ ...prevLoad, [name]: value }));
  };

  const handleCheckboxChange = (e) => {
    setNewLoad((prevLoad) => ({
      ...prevLoad,
      isDangerousGoods: e.target.checked,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    await axios.post("https://localhost:7028/api/cargoloads", newLoad);
    fetchCargoLoads();
    setModalIsOpen(false);
  };

  return (
    <div className="container mt-5">
      <h1 className="mb-4">Cargo Load Management</h1>
      <table className="table table-striped table-bordered">
        <thead className="thead-dark">
          <tr>
            <th>Driver's Full Name</th>
            <th>Vehicle Number</th>
            <th>Vehicle Type</th>
            <th>Load Weight</th>
            <th>Dangerous Goods</th>
          </tr>
        </thead>
        <tbody>
          {cargoLoads.map((load) => (
            <tr key={load.id}>
              <td>{load.driverName}</td>
              <td>{load.vehicleNumber}</td>
              <td>{load.vehicleType}</td>
              <td>{load.loadWeight}</td>
              <td>{load.isDangerousGoods ? "Yes" : "No"}</td>
            </tr>
          ))}
        </tbody>
      </table>

      <button className="btn btn-primary" onClick={() => setModalIsOpen(true)}>
        Add New Load
      </button>

      <Modal
        isOpen={modalIsOpen}
        onRequestClose={() => setModalIsOpen(false)}
        contentLabel="Add New Load"
      >
        <h2>Add New Load</h2>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Driver's Full Name:</label>
            <input
              type="text"
              name="driverName"
              className="form-control"
              value={newLoad.driverName}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Vehicle Number:</label>
            <input
              type="text"
              name="vehicleNumber"
              className="form-control"
              value={newLoad.vehicleNumber}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group">
            <label>Vehicle Type:</label>
            <select
              name="vehicleType"
              className="form-control"
              value={newLoad.vehicleType}
              onChange={handleInputChange}
            >
              <option value="truck">Truck</option>
              <option value="cistern">Cistern</option>
              <option value="tent">Tent</option>
            </select>
          </div>
          <div className="form-group">
            <label>Load Weight:</label>
            <input
              type="number"
              name="loadWeight"
              className="form-control"
              value={newLoad.loadWeight}
              onChange={handleInputChange}
              required
            />
          </div>
          <div className="form-group form-check">
            <input
              type="checkbox"
              className="form-check-input"
              checked={newLoad.isDangerousGoods}
              onChange={handleCheckboxChange}
            />
            <label className="form-check-label">Dangerous Goods</label>
          </div>
          <button type="submit" className="btn btn-success">
            Add Load
          </button>
        </form>
        <button
          className="btn btn-secondary mt-3"
          onClick={() => setModalIsOpen(false)}
        >
          Close
        </button>
      </Modal>
    </div>
  );
}

export default CargoLoadManagement;
