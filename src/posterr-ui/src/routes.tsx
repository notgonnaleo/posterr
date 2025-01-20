import { Routes, Route } from 'react-router-dom';
import Blog from './pages/Blog';

const RouteProvider = () => {
  return (
    <Routes>
      <Route path="/" element={<Blog />} />
    </Routes>
  );
};

export default RouteProvider;