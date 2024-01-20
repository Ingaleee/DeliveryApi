import React from 'react';

function AddOrderForm({ onAddOrder }) {
  const [formData, setFormData] = React.useState({
    senderCity: '',
    senderAddress: '',
    recipientCity: '',
    recipientAddress: '',
    weight: '',
    pickupDateUtc: '',
  });

  const handleInputChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleAddOrder = async () => {
    const requestOptions = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        SenderCity: formData.senderCity,
        SenderAddress: formData.senderAddress,
        RecipientCity: formData.recipientCity,
        RecipientAddress: formData.recipientAddress,
        Weight: parseFloat(formData.weight),
        PickupDateUtc: new Date(formData.pickupDateUtc),
      }),
    };

    try {
      const response = await fetch('http://localhost:5110/api/orders/', requestOptions);
      
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }

      const newOrder = await response.json();
      onAddOrder(newOrder);
    } catch (error) {
      console.error('Fetch error:', error);
    }
  };

  return (
    <div>
      <form>
        <label>
          Sender City:
          <input type="text" name="senderCity" onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Sender Address:
          <input type="text" name="senderAddress" onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Recipient City:
          <input type="text" name="recipientCity" onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Recipient Address:
          <input type="text" name="recipientAddress" onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Weight:
          <input type="text" name="weight" onChange={handleInputChange} />
        </label>
        <br />
        <label>
          Pickup Date UTC:
          <input type="text" name="pickupDateUtc" onChange={handleInputChange} />
        </label>
        <br />
        <button type="button" onClick={handleAddOrder}>
          Add Order
        </button>
      </form>
    </div>
  );
}

export default AddOrderForm;