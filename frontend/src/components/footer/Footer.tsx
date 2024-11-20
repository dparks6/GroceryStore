const Footer = () => {
  return (
    <footer className="bg-inherit">
        {/* <div className="flex flex-row justify-evenly text-sm text-zinc-500 p-1">
            <p>About</p>
            <p>Terms of Service</p>
            <p>Contact Us</p>          
            <p>Careers</p>
            <p>Advertising</p>
            <p>Privacy Policy</p>
            <p>Cookie Policy</p>
            <p>Help Center</p>
            <p>© 2024 ShopQuik Corp.</p>  
        </div> */}
      {/* <div className="p-">
          <a href="">About</a>
          <a href="">Terms of Service</a>
          <a href="">Contact Us</a>
          <a href="">Careers</a>
          <a href="">Support</a>
          <a href="">Privacy Policy</a>
      </div> */}
  <div className="max-w-full mx-auto mx-5">
    <div className="grid grid-cols-1 md:grid-cols-4 gap-8 py-12 border-b border-gray-700">
      {/* Logo and About */}
      <div>
        <h3 className="text-lg font-semibold mb-4">ShopQuik</h3>
        <p className="text-sm text-green-900">
          Delivering quality food and innovative solutions for a better diet!
        </p>
      </div>
      
      {/* Links */}
      <div>
        <h3 className="text-lg font-semibold mb-4">Links</h3>
        <ul className="space-y-2 text-sm">
          <li><a href="#" className="hover:text-blue-500">Home</a></li>
          <li><a href="#" className="hover:text-blue-500">About Us</a></li>
          <li><a href="#" className="hover:text-blue-500">Services</a></li>
          <li><a href="#" className="hover:text-blue-500">Contact</a></li>
        </ul>
      </div>

      {/* Support */}
      <div>
        <h3 className="text-lg font-semibold mb-4">Support</h3>
        <ul className="space-y-2 text-sm">
          <li><a href="#" className="hover:text-blue-500">Help Center</a></li>
          <li><a href="#" className="hover:text-blue-500">Privacy Policy</a></li>
          <li><a href="#" className="hover:text-blue-500">Terms of Service</a></li>
        </ul>
      </div>
      
      {/* Newsletter */}
      <div>
        <h3 className="text-lg font-semibold mb-4">Subscribe</h3>
        <p className="text-sm text-gray-600 mb-4">
          Join our newsletter to stay updated.
        </p>
        <form className="flex">
          <input 
            type="email" 
            className="w-full px-4 py-2 rounded-l-md border border-gray-600 bg-gray-700 text-sm text-white placeholder-gray-400 focus:ring-2 focus:ring-gray-500" 
            placeholder="Enter your email!" 
          />
          <button 
            type="submit" 
            className="bg-blue-600 px-4 py-2 rounded-r-md text-sm font-medium hover:bg-blue-700">
            Subscribe
          </button>
        </form>
      </div>
    </div>

    {/* Footer Bottom */}
    <div className="flex justify-between items-center py-4 text-sm">
      <p>&copy; 2024 ShopQuik. All Rights Reserved.</p>
      <div className="space-x-2">
        <a href="#" className="hover:text-blue-500">Facebook</a>
        <a href="#" className="hover:text-blue-500">Twitter</a>
        <a href="#" className="hover:text-blue-500">Instagram</a>
        <a href="#" className="hover:text-blue-500">LinkedIn</a>
      </div>
    </div>
  </div>

    </footer>
  );
};

export default Footer;
