import React, { useState, useEffect } from "react";
import axios from "axios";
import Modal from "react-modal";

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
    <div>
      <h1>Cargo Load Management</h1>
      <table>
        <thead>
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

      <button onClick={() => setModalIsOpen(true)}>Add New Load</button>

      <Modal
        isOpen={modalIsOpen}
        onRequestClose={() => setModalIsOpen(false)}
        contentLabel="Add New Load"
      >
        <h2>Add New Load</h2>
        <form onSubmit={handleSubmit}>
          <label>
            Driver's Full Name:
            <input
              type="text"
              name="driverName"
              value={newLoad.driverName}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Vehicle Number:
            <input
              type="text"
              name="vehicleNumber"
              value={newLoad.vehicleNumber}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Vehicle Type:
            <select
              name="vehicleType"
              value={newLoad.vehicleType}
              onChange={handleInputChange}
            >
              <option value="truck">Truck</option>
              <option value="cistern">Cistern</option>
              <option value="tent">Tent</option>
            </select>
          </label>
          <label>
            Load Weight:
            <input
              type="number"
              name="loadWeight"
              value={newLoad.loadWeight}
              onChange={handleInputChange}
              required
            />
          </label>
          <label>
            Dangerous Goods:
            <input
              type="checkbox"
              checked={newLoad.isDangerousGoods}
              onChange={handleCheckboxChange}
            />
          </label>
          <button type="submit">Add Load</button>
        </form>
        <button onClick={() => setModalIsOpen(false)}>Close</button>
      </Modal>
    </div>
  );
}

export default CargoLoadManagement;
