import React from 'react';
import { IApiOptions } from '../../lib/interfaces/api/IApiOptions';
import { IStatelessApi } from '../../lib/interfaces/api/IStatelessApi';
import { useEndpoint } from './useEndpoint';

export const useStatelessApi = <T>() => {
  const apiOptionsRef = React.useRef<IApiOptions>({} as IApiOptions);
  const { getServiceUrl } = useEndpoint();
  const [isLoading, setIsLoading] = React.useState<boolean>(false);

  const get = React.useCallback(
    async (options?: Partial<IApiOptions>): Promise<T | null> => {
      if (options !== undefined) {
        apiOptionsRef.current = { ...apiOptionsRef.current, ...options };
      }

      setIsLoading(true);

      const response = await fetch(
        getServiceUrl(apiOptionsRef.current?.serviceUrl) +
          apiOptionsRef.current.parameters,
        {
          method: 'GET',
          mode: 'cors',
          headers: {
            'Content-Type': 'application/json',
          },
        }
      ).then(async (res) => {
        if (res.ok) {
          const parsedObject: T = await JSON.parse(
            await JSON.stringify(await res.json())
          );

          return parsedObject;
        }

        return null;
      });

      setIsLoading(false);

      return response;
    },
    [getServiceUrl]
  );

  const post = React.useCallback(
    async (options: Partial<IApiOptions>): Promise<void> => {
      if (options !== undefined) {
        apiOptionsRef.current = { ...apiOptionsRef.current, ...options };
      }

      setIsLoading(true);

      await fetch(
        getServiceUrl(apiOptionsRef.current?.serviceUrl) +
          apiOptionsRef.current.parameters,
        {
          method: 'POST',
          mode: 'cors',
          headers: {
            'Content-Type': 'application/json',
          },
          body: apiOptionsRef.current.requestOptions.body,
        }
      );

      setIsLoading(false);
    },
    [getServiceUrl]
  );

  const postWithContent = React.useCallback(
    async (options: Partial<IApiOptions>): Promise<T | null> => {
      if (options !== undefined) {
        apiOptionsRef.current = { ...apiOptionsRef.current, ...options };
      }

      setIsLoading(true);
      const response = await fetch(
        getServiceUrl(apiOptionsRef.current?.serviceUrl) +
          apiOptionsRef.current.parameters,
        {
          method: 'POST',
          mode: 'cors',
          headers: {
            'Content-Type': 'application/json',
          },
          body: apiOptionsRef.current.requestOptions.body,
        }
      ).then(async (res) => {
        if (res.ok) {
          const parsedObject: T = await JSON.parse(
            await JSON.stringify(await res.json())
          );

          return parsedObject;
        }

        return null;
      });

      setIsLoading(false);

      return response;
    },
    [getServiceUrl]
  );

  const rebind = React.useCallback(async () => {
    return await get();
  }, [get]);

  const create = React.useCallback(
    (options: IApiOptions): IStatelessApi<T> => {
      apiOptionsRef.current = options;

      return {
        isLoading,
        get,
        post,
        postWithContent,
        rebind,
      };
    },
    [isLoading, get, post, rebind, postWithContent]
  );

  return {
    create,
  };
};
