import React, { useEffect, useState } from 'react';

interface IContainerDimension {
  width: number;
  height: number;
}

export const useContainerDimensions = (
  ref: React.MutableRefObject<HTMLDivElement | null>,
  fallbackWidth: number,
  fallbackHeight: number
) => {
  const [dimensions, setDimensions] = useState<IContainerDimension>({
    width: fallbackWidth,
    height: fallbackHeight,
  });

  const getDimensions = React.useCallback((): IContainerDimension => {
    return {
      width: ref?.current?.offsetWidth ?? 1000,
      height: ref?.current?.offsetHeight ?? 400,
    };
  }, [ref]);

  useEffect(() => {
    if (ref != null) {
      const handleResize = () => {
        setDimensions(getDimensions());
      };

      if (ref.current) {
        setDimensions(getDimensions());
      }

      window.addEventListener('resize', handleResize);

      return () => {
        window.removeEventListener('resize', handleResize);
      };
    }
  }, [ref, getDimensions]);

  return dimensions;
};
