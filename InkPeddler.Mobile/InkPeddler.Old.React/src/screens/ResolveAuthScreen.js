import { useContext, useEffect } from 'react';
import { Context as SecurityContext } from '../context/SecurityContext';

const ResolveAuthScreen = () => {
  const { resolveAuthentication } = useContext(SecurityContext);

  useEffect(() => {
    resolveAuthentication();
  }, []);

  return null;
};

export default ResolveAuthScreen;