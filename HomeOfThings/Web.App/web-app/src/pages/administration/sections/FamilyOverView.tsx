import React, { CSSProperties } from 'react';
import { StyledList } from '../../../components/styledComponents/StyledLists';
import { IFamily } from '../interfaces/IFamily';
import FamilyListItem from '../components/FamilyListItem';
import { useStatelessApi } from '../../../hooks/api/useStatelessApi';
import { ApiEndpointEnum } from '../../../lib/enums/ApiEndpointEnum';

interface IProps {
  selectedSection: number;
  sectionId: number;
}

const FamilyOverview: React.FC<IProps> = (props) => {
  const { sectionId, selectedSection } = props;

  const [families, setFamilies] = React.useState<IFamily[] | null>(null);

  const familyMemberApi = useStatelessApi<IFamily[]>().create({
    serviceUrl: ApiEndpointEnum.GetFamilyMembers,
    requestOptions: {
      method: 'GET',
      mode: 'cors',
    },
    parameters: '',
  });

  const familyUpdateApi = useStatelessApi<boolean>().create({
    serviceUrl: ApiEndpointEnum.UpdateFamily,
    requestOptions: {
      method: 'POST',
      mode: 'cors',
    },
    parameters: '',
  });

  const requestFamilyMembers = React.useCallback(async () => {
    const result = await familyMemberApi.get({
      serviceUrl: ApiEndpointEnum.GetFamilyMembers,
      requestOptions: {
        method: 'GET',
        mode: 'cors',
      },
      parameters: '',
    });

    if (result != null) {
      setFamilies(result);
    }
  }, [familyMemberApi]);

  React.useEffect(() => {
    if (sectionId === selectedSection) {
      requestFamilyMembers();
    }
    // eslint-disable-next-line
  }, [sectionId, selectedSection]);

  const listStyle: CSSProperties = {
    width: '100%',
    maxHeight: '600px',
    overflowX: 'scroll',
  };

  const handleCheckedChange = React.useCallback(
    async (isActive: boolean, index: number) => {
      const copy = families?.slice() ?? [];
      copy[index] = { ...copy[index], isActive: isActive };

      const updateResult = await familyUpdateApi.postWithContent({
        serviceUrl: ApiEndpointEnum.UpdateFamily,
        requestOptions: {
          method: 'POST',
          mode: 'cors',
          body: JSON.stringify(copy[index]),
        },
        parameters: '',
      });

      if (updateResult) {
        await requestFamilyMembers();
      }
    },
    [familyUpdateApi, families, requestFamilyMembers]
  );

  if (sectionId !== selectedSection || families == null) {
    return null;
  }

  return (
    <StyledList disablePadding style={listStyle}>
      {families?.map((family, index) => (
        <FamilyListItem
          key={index}
          index={index}
          family={family}
          isActive={family.isActive}
          handleCheckedChanged={handleCheckedChange}
        />
      ))}
    </StyledList>
  );
};

export default FamilyOverview;
