import React, { useState, useEffect } from "react";
import axios from "axios";

function ExportCargoLoads() {
  const [cargoLoads, setCargoLoads] = useState([]);
  const [selectedLoads, setSelectedLoads] = useState([]);

  useEffect(() => {
    fetchCargoLoads();
  }, []);

  const fetchCargoLoads = async () => {
    const response = await axios.get("http://localhost:5000/api/cargoloads");
    setCargoLoads(response.data);
  };

  const handleSelectionChange = (id) => {
    setSelectedLoads((prev) =>
      prev.includes(id) ? prev.filter((loadId) => loadId !== id) : [...prev, id]
    );
  };

  const handleExport = () => {
    const selectedData = cargoLoads.filter((load) =>
      selectedLoads.includes(load.id)
    );
    const blob = new Blob([JSON.stringify(selectedData, null, 2)], {
      type: "application/json",
    });
    const link = document.createElement("a");
    link.href = URL.createObjectURL(blob);
    link.download = "selected_cargo_loads.json";
    link.click();
  };

  return (
    <div>
      <h1>Export Cargo Loads</h1>
      <table>
        <thead>
          <tr>
            <th>Select</th>
            <th>Driver's Full Name</th>
            <th>Vehicle Number</th> <th>Vehicle Type</th> <th>Load Weight</th>{" "}
            <th>Dangerous Goods</th>{" "}
          </tr>{" "}
        </thead>{" "}
        <tbody>
          {" "}
          {cargoLoads.map((load) => (
            <tr key={load.id}>
              {" "}
              <td>
                {" "}
                <input
                  type="checkbox"
                  checked={selectedLoads.includes(load.id)}
                  onChange={() => handleSelectionChange(load.id)}
                />{" "}
              </td>{" "}
              <td>{load.driverName}</td> <td>{load.vehicleNumber}</td>{" "}
              <td>{load.vehicleType}</td> <td>{load.loadWeight}</td>{" "}
              <td>{load.isDangerousGoods ? "Yes" : "No"}</td>{" "}
            </tr>
          ))}{" "}
        </tbody>{" "}
      </table>{" "}
      <button onClick={handleExport}>Export Selected Loads</button>{" "}
    </div>
  );
}

export default ExportCargoLoads;
