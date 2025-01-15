import Button from '@mui/material/Button';

const handleClick = () => {
  alert("Button clicked!");
};

const Homepage = () => {
  return (
    <>
      <p className="read-the-docs">
        My pretty homepage
        <Button variant="contained"  onClick={handleClick}>Hello world</Button>
      </p>
    </>
  )
}

export default Homepage
