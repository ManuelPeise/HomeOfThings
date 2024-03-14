import React from 'react';
import SettingsPageLayout from '../../components/layouts/SettingsPageLayout';
import { useI18n } from '../../hooks/useI18n';
import { IListItem } from '../../lib/interfaces/list/IListItem';
import FamilyOverview from './sections/FamilyOverView';
import AddFamilySection from './sections/AddFamilySection';
import { StyledPaper } from '../../components/styledComponents/StyledLayout';

const SystemAdministration: React.FC = () => {
  const { getResource } = useI18n();
  const [selectedItem, setSelectedItem] = React.useState<number>(0);

  const listItems = React.useMemo((): IListItem[] => {
    return [
      { id: 0, title: getResource('administration.labelOverview') },
      { id: 1, title: getResource('administration.labelAddNewFamily') },
    ];
  }, [getResource]);

  const handleSelectItem = React.useCallback((id: number) => {
    setSelectedItem(id);
  }, []);

  return (
    <SettingsPageLayout
      pageTitle={getResource('administration.labelFamilyAdministration')}
      selectedItem={selectedItem}
      listItems={listItems}
      handleItemClicked={handleSelectItem}
    >
      <StyledPaper>
        <FamilyOverview sectionId={0} selectedSection={selectedItem} />
        <AddFamilySection sectionId={1} selectedSection={selectedItem} />
      </StyledPaper>
    </SettingsPageLayout>
  );
};

export default SystemAdministration;
