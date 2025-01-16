import { Routes, Route } from 'react-router-dom';
import Homepage from './pages/Home';
import Blog from './pages/Blog';

const RouteProvider = () => {
  return (
    <Routes>
      <Route path="/" element={<Homepage />} />
      <Route path="/blog" element={<Blog />} />
    </Routes>
  );
};

export default RouteProvider;