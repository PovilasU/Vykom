import React, { useState, useEffect } from "react";
import axios from "axios";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faFileExport } from "@fortawesome/free-solid-svg-icons";
import Select from "react-select";

function ExportCargoLoads() {
  const [cargoLoads, setCargoLoads] = useState([]);
  const [selectedLoads, setSelectedLoads] = useState([]);

  useEffect(() => {
    fetchCargoLoads();
  }, []);

  const fetchCargoLoads = async () => {
    const response = await axios.get("https://localhost:7028/api/cargoloads");
    setCargoLoads(response.data);
  };

  const handleSelectionChange = (selectedOptions) => {
    setSelectedLoads(
      selectedOptions ? selectedOptions.map((option) => option.value) : []
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

  const options = cargoLoads.map((load) => ({
    value: load.id,
    label: `${load.driverName} - ${load.vehicleNumber}`,
  }));

  return (
    <div>
      <h1>Export Cargo Loads</h1>
      <Select
        isMulti
        options={options}
        onChange={handleSelectionChange}
        placeholder="Select cargo loads..."
      />
      <button onClick={handleExport}>
        <FontAwesomeIcon icon={faFileExport} /> Export Selected Loads
      </button>
    </div>
  );
}

export default ExportCargoLoads;
