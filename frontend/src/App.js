import React from 'react';
import Button from '@material-ui/core/Button';
import AddOrderForm from './components/AddOrderForm';
import Order from './components/Order';

function App() {
  const [orders, setOrders] = React.useState([]);
  const [showAddForm, setShowAddForm] = React.useState(false);

  React.useEffect(() => {
    const url = "http://localhost:5110/api/orders";

    fetch(url)
      .then(response => {
        if (!response.ok) {
          throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
      })
      .then(data => {
        setOrders(data);
      })
      .catch(error => {
        console.error('Fetch error:', error);
      });
  }, []); 
  
  const handleAddOrder = (newOrder) => {
    setOrders([...orders, { id: orders.length + 1, ...newOrder }]);
    setShowAddForm(false);
  };
  
  return (
    <div>
      <Button onClick={() => setShowAddForm(true)}>Add Order</Button>
      {showAddForm && <AddOrderForm onAddOrder={handleAddOrder} />}
      <ul>
        {orders.map((x) => (
          <li key={x.id}>
            <Order order={x}></Order>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;