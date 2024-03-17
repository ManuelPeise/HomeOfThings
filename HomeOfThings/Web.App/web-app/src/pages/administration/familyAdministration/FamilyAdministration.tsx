import React from 'react';
import { useI18n } from '../../../hooks/useI18n';
import { IListItem } from '../../../lib/interfaces/list/IListItem';
import FamilyOverview from './sections/FamilyOverView';
import AddFamilySection from './sections/AddFamilySection';

import SettingsLayout from '../../../components/layouts/SettingsLayout';

const FamilyAdministration: React.FC = () => {
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
    <SettingsLayout
      pageTitle={getResource('common.labelFamilyAdministration')}
      selectedItem={selectedItem}
      listItems={listItems}
      handleItemClicked={handleSelectItem}
    >
      <>
        <FamilyOverview sectionId={0} selectedSection={selectedItem} />
        <AddFamilySection sectionId={1} selectedSection={selectedItem} />
      </>
    </SettingsLayout>
  );
};

export default FamilyAdministration;
